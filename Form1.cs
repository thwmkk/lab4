namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<Plants> plantsList = new List<Plants>();

        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.plantsList.Clear();
            for (var i = 0; i < 10; ++i)
            {
                switch (Plants.rnd.Next() % 3) // генерирую случайное число от 0 до 2 (ну остаток от делени€ на 3)
                {
                    case 0:
                        this.plantsList.Add(Flowers.Generate());
                        break;
                    case 1:
                        this.plantsList.Add(Shrubs.Generate());
                        break;
                    case 2:
                        this.plantsList.Add(Trees.Generate());
                        break;
                }
            }
            ShowInfo();
        }
        private void ShowInfo()
        {
            int flowersCount = 0;
            int shrubsCount = 0;
            int treesCount = 0;

            // пройдемс€ по всему списку
            foreach (var plant in this.plantsList)
            {
                if (plant is Flowers)
                {
                    flowersCount += 1;

                    queueTxtBox.Text += "÷веток\n";
                }
                else if (plant is Shrubs)
                {
                    shrubsCount += 1;

                    queueTxtBox.Text += " устарник\n";
                }
                else if (plant is Trees)
                {
                    treesCount += 1;

                    queueTxtBox.Text += "ƒерево\n";
                }
            }

            // а ну и вывести все это надо на форму
            txtInfo.Text = "÷веты\t устарники\tƒеревь€"; // буквы экнмлю, чтобы влезло на форму
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t\t{2}", flowersCount, shrubsCount, treesCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.plantsList.Count == 0)
            {
                txtOut.Text = "ѕусто Q_Q";
                return;
            }

            var plant = this.plantsList[0];
            this.plantsList.RemoveAt(0);

            txtOut.Text = plant.GetInfo();
            queueTxtBox.Text = "";
            ShowInfo();
        }

        private void queueTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}