using System.Data.Common;

namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private Label[,] labelsMap;
        private const int mapSize = 4;
        private static Random random = new Random();


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load (object sender, EventArgs e)
        {
            InitMap();
            GenerateNumber();
        }

        
        private void InitMap()
        {
            labelsMap = new Label[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;
                }
            }
        }

        private void GenerateNumber()
        {
            var emptyCell = new List<(int indexRow, int indexColumn)>();
            for(int i = 0; i < mapSize; i++)
            {
                for(int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i,j].Text == string.Empty)
                    {
                        emptyCell.Add((i, j));
                    }
                }
            }

            if (emptyCell.Count == 0)
            {
                return;
            }

            var randomNumberLabel = random.Next(emptyCell.Count);

            int number;
            if (random.Next(100) < 90)
            {
                number = 2;
            }
            else
            {
                number = 4;
            }
            var (indexRow, indexColumn) = emptyCell[randomNumberLabel];
            labelsMap[indexRow, indexColumn].Text = number.ToString();
                                  
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.ButtonShadow;
            label.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label.Size = new Size(70, 70);
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = 30 + indexColumn * 76;
            int y = 24 + indexRow * 76;
            label.Location = new Point(x, y);
            return label;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {

            }

            if (e.KeyCode == Keys.Left)
            {

            }

            if (e.KeyCode == Keys.Up)
            {

            }

            if (e.KeyCode == Keys.Down)
            {

            }
        }
    }
}
