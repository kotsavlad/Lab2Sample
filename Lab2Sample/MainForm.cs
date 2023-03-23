#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lab2Sample
{
    public partial class MainForm : Form
    {
        private bool _isMatrix1Loaded;
        private bool _isMatrix2Loaded;
        private readonly string _dataDir = @"DataFiles";

        public MainForm()
        {
            InitializeComponent();
            _dataDir = Directory.GetParent(Environment.CurrentDirectory)?.FullName + @$"\{_dataDir}";
        }

        private bool TryFillGrid(DataGridView grid, string fileName = "")
        {
            openFileDialog.InitialDirectory = Directory.Exists(_dataDir)
                ? _dataDir
                : Environment.CurrentDirectory;
            openFileDialog.FileName = fileName;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            bool errorOccurred = false;
            grid.SuspendLayout();
            try
            {
                using var reader = new StreamReader(openFileDialog.FileName);
                var firstLine = reader.ReadLine();
                var row = firstLine?.Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int columnCount = row?.Length ?? 0;
                if (columnCount == 0)
                {
                    throw new ArgumentException($"First line of {openFileDialog.FileName} is empty");
                }

                grid.Rows.Clear();
                grid.ColumnCount = columnCount;
                grid.Rows.Add(row!);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine() ?? "";
                    row = Regex.Split(line, @"\s+");
                    if (row.Length != columnCount)
                    {
                        throw new ArgumentException(
                            $"Invalid item count in line #{grid.Rows.Count + 1} of \"{openFileDialog.FileName}\"");
                    }

                    for (int i = 0; i < row.Length; i++)
                    {
                        if (!int.TryParse(row[i], out _))
                        {
                            throw new ArgumentException(
                                $"Invalid item #{i + 1} in line #{grid.Rows.Count + 1} of \"{openFileDialog.FileName}\"");
                        }
                    }

                    grid.Rows.Add(Array.ConvertAll(row, x => (object)x));
                }

                foreach (DataGridViewColumn column in grid.Columns)
                {
                    column.MinimumWidth = 40;
                }

                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception e)
            {
                grid.Rows.Clear();
                grid.Columns.Clear();
                MessageBox.Show(e.Message, "Data error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorOccurred = true;
            }
            finally
            {
                grid.ResumeLayout();
            }

            return !errorOccurred;
        }

        private bool TryParseGrid(DataGridView grid, out int[,] matrix)
        {
            matrix = new int[grid.RowCount, grid.ColumnCount];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    try
                    {
                        matrix[i, j] = Convert.ToInt32(grid[j, i].Value);
                    }
                    catch
                    {
                        MessageBox.Show($@"Invalid value {grid[j, i].Value} in cell ({i}, {j}) of {grid.Name}");
                        return false;
                    }
                }
            }

            return true;
        }

        private void loadMatrix1Button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Select datafile for the first matrix", "Matrix 1 selection", MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
            _isMatrix1Loaded = TryFillGrid(matrixGrid1, "matrix1.txt");
            task1Button.Enabled = task2Button.Enabled = _isMatrix1Loaded && _isMatrix2Loaded;
            saveMatrix1Button.Enabled = _isMatrix1Loaded;
        }

        private void loadMatrix2Button_Click(object sender, EventArgs e)
        {
            _isMatrix2Loaded = TryFillGrid(matrixGrid2, "matrix2.txt");
            task1Button.Enabled = task2Button.Enabled = _isMatrix1Loaded && _isMatrix2Loaded;
            saveMatrix2Button.Enabled = _isMatrix2Loaded;
        }

        private void task1Button_Click(object sender, EventArgs e)
        {
            if (TryParseGrid(matrixGrid1, out var matrix1) && TryParseGrid(matrixGrid2, out var matrix2))
            {
                var (m1, n1) = (matrix1.GetLength(0), matrix1.GetLength(1));
                var (m2, n2) = (matrix2.GetLength(0), matrix2.GetLength(1));
                if (m1 != m2 &&
                    MessageBox.Show(
                        "Matrices have different numbers of rows. Do you wish to perform checking only on the common rows",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                int m = Math.Min(m1, m2);
                var maxInRows = new int[m];
                for (int i = 0; i < m; i++)
                {
                    maxInRows[i] = matrix2[i, 0];
                    for (int j = 1; j < n2; j++)
                    {
                        maxInRows[i] = Math.Max(maxInRows[i], matrix2[i, j]);
                    }
                }

                bool areSelectedColumns = false;
                for (int j = 0; j < n1; j++)
                {
                    bool columnSelectionNeeded = true;
                    for (int i = 1; i < m; i++)
                    {
                        if (matrix1[i, j] < maxInRows[i])
                        {
                            columnSelectionNeeded = false;
                            break;
                        }
                    }

                    areSelectedColumns |= columnSelectionNeeded;
                    matrixGrid1.Columns[j].DefaultCellStyle.BackColor = columnSelectionNeeded
                        ? Color.Aqua
                        : matrixGrid1.DefaultCellStyle.BackColor;
                    //matrixGrid1.Columns[j].DefaultCellStyle.Font = columnSelectionNeeded
                    //    ? new Font(matrixGrid1.DefaultCellStyle.Font, FontStyle.Bold)
                    //    : new Font(matrixGrid1.DefaultCellStyle.Font, FontStyle.Regular);
                }

                if (!areSelectedColumns)
                    MessageBox.Show("None row satisfies the selection conditions", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
            }
        }

        private void matrixGrid1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (sender is DataGridView grid)
            {
                grid.Rows[e.RowIndex].ErrorText = "";
                if (!int.TryParse(e.FormattedValue.ToString(), out _))
                {
                    grid.Rows[e.RowIndex].ErrorText = $"{e.FormattedValue} is invalid value for numerical data";
                    e.Cancel = true;
                }
            }
        }

        private void matrixGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void task2Button_Click(object sender, EventArgs e)
        {
            var counts1 = TryParseGrid(matrixGrid1, out var matrix1)
                ? GetCountOfDifferent(matrix1)
                : Array.Empty<int>();
            var counts2 = TryParseGrid(matrixGrid1, out var matrix2)
                ? GetCountOfDifferent(matrix2)
                : Array.Empty<int>();
            var chartForm = new ChartForm(counts1, counts2);
            chartForm.ShowDialog();

            int[] GetCountOfDifferent(int[,] matrix)
            {
                var (m, n) = (matrix.GetLength(0), matrix.GetLength(1));
                var counts = new int[matrix.GetLength(0)];
                for (int i = 0; i < m; i++)
                {
                    var rowItemsSet = new HashSet<int>();
                    for (int j = 0; j < n; j++)
                    {
                        rowItemsSet.Add(matrix[i, j]);
                    }

                    counts[i] = rowItemsSet.Count;
                }

                return counts;
            }
        }

        private void SaveMatrix(DataGridView matrixGrid)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var writer = new StreamWriter(saveFileDialog.FileName);
                    foreach (DataGridViewRow row in matrixGrid.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            writer.Write(cell.Value + "\t");
                        }

                        writer.WriteLine();
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveMatrix1Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == saveMatrix1Button)
                {
                    SaveMatrix(matrixGrid1);
                }
                else if (button == saveMatrix2Button)
                {
                    SaveMatrix(matrixGrid2);
                }
            }
        }
    }
}