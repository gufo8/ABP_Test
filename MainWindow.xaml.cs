using ABP_Test.Models;
using ABP_Test.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ABP_Test
{   
    public partial class MainWindow : Window
    {
        //private readonly MyDBContext context = new MyDBContext();
        HTMLScrapper scrapper;
        List<string> ListUrlPage2 = new List<string>()
        {
            "https://catcar.info/toyota/?lang=en&l=bWFya2V0PT1ldXJvfHxzdD09MzB8fHN0cz09eyIxMCI6IlJlZ2lvbiIsIjIwIjoiRXVyb3BlIiwiMzAiOiI0LVJVTk5FUiBUUlVDSyA2NzE0NDAifXx8Y2F0YWxvZz09NjcxNDQwfHxyZWM9PUEx",
            "https://catcar.info/toyota/?lang=en&l=bWFya2V0PT1ldXJvfHxzdD09MzB8fHN0cz09eyIxMCI6IlJlZ2lvbiIsIjIwIjoiRXVyb3BlIiwiMzAiOiI0LVJVTk5FUiBUUlVDSyAoSlBQKSA2NzE0NTAifXx8Y2F0YWxvZz09NjcxNDUwfHxyZWM9PUEx",
            "https://catcar.info/toyota/?lang=en&l=bWFya2V0PT1ldXJvfHxzdD09MzB8fHN0cz09eyIxMCI6IlJlZ2lvbiIsIjIwIjoiRXVyb3BlIiwiMzAiOiI0LVJVTk5FUiBUUlVDSyAoSlBQKSA2NzI0NTAifXx8Y2F0YWxvZz09NjcyNDUwfHxyZWM9PUEx"
        };
        
        public MainWindow()
        {
            InitializeComponent();
            scrapper = new HTMLScrapper();

            ListModels.ItemsSource = scrapper.CarModelsNames;
            List2.ItemsSource = scrapper.ComplectationsBody;
            List3.ItemsSource = scrapper.GroupPartsNames;
            List4.ItemsSource = scrapper.SubGroupNames;
            List5.ItemsSource = scrapper.SparePartNames;

            //ListModels.SelectedIndex = scrapper.ListCarModelsNamesSelectedInd;
        }

        //Page1
        //to save time, did not implement commands
        // used events
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            scrapper.GetListCarModelAndCodes($"https://catcar.info/toyota/?lang=en&l=bWFya2V0PT1ldXJvfHxzdD09MjB8fHN0cz09eyIxMCI6IlJlZ2lvbiIsIjIwIjoiRXVyb3BlIn0%3D");
            //MessageBoxResult msrlt = MessageBox.Show($"Index {ListModels.SelectedIndex}", "Delete element", MessageBoxButton.YesNo);
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            scrapper.GetListComplectations("https://catcar.info/toyota/?lang=en&l=bWFya2V0PT1ldXJvfHxzdD09MzB8fHN0cz09eyIxMCI6IlJlZ2lvbiIsIjIwIjoiRXVyb3BlIiwiMzAiOiI0LVJVTk5FUiBUUlVDSyA2NzE0NDAifXx8Y2F0YWxvZz09NjcxNDQwfHxyZWM9PUEx");
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            scrapper.GetGroupParts($"https://catcar.info/toyota/?lang=en&l=bWFya2V0PT1ldXJvfHxzdD09NjB8fHN0cz09eyIxMCI6IlJlZ2lvbiIsIjIwIjoiRXVyb3BlIiwiMzAiOiI0LVJVTk5FUiBUUlVDSyA2NzE0NDAiLCI2MCI6IkxONTFMLUtSQSJ9fHxjYXRhbG9nPT02NzE0NDB8fHJlYz09QTF8fG1vZGlmbmFtZT09TE41MUwtS1JBfHxlbmdpbmU9PTJMfHxtb2RlbG5vPT0wMDF8fFByb2RQZXJpb2Q9PTE5ODQwODE5ODUwOHx8bW9kX2luZm8wPT1UMXx8bW9kX2luZm8xPT1TVER8fG1vZF9pbmZvMj09TVRNfHxtb2RfaW5mbzM9PTRGfHxtb2RfaW5mbzQ9PVJDQnx8bW9kX2luZm81PT1HfHxtb2RfaW5mbzY9PUhMRnx8bW9kX2luZm83PT1TVHx8bW9kX2luZm84PT1VU0F8fG1vZF9pbmZvOT09RFNMfHxtb2RfaW5mbzEwPT1DQlV8fHBhZ2U2MD09MDAx");
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            scrapper.GetSubgroups($"https://catcar.info/toyota/?lang=en&l=bWFya2V0PT1ldXJvfHxzdD09NjB8fHN0cz09eyIxMCI6IlJlZ2lvbiIsIjIwIjoiRXVyb3BlIiwiMzAiOiI0LVJVTk5FUiBUUlVDSyA2NzE0NDAiLCI2MCI6IkxONTFMLUtSQSJ9fHxjYXRhbG9nPT02NzE0NDB8fHJlYz09QTF8fG1vZGlmbmFtZT09TE41MUwtS1JBfHxlbmdpbmU9PTJMfHxtb2RlbG5vPT0wMDF8fFByb2RQZXJpb2Q9PTE5ODQwODE5ODUwOHx8bW9kX2luZm8wPT1UMXx8bW9kX2luZm8xPT1TVER8fG1vZF9pbmZvMj09TVRNfHxtb2RfaW5mbzM9PTRGfHxtb2RfaW5mbzQ9PVJDQnx8bW9kX2luZm81PT1HfHxtb2RfaW5mbzY9PUhMRnx8bW9kX2luZm83PT1TVHx8bW9kX2luZm84PT1VU0F8fG1vZF9pbmZvOT09RFNMfHxtb2RfaW5mbzEwPT1DQlV8fHBhZ2U2MD09MDAx");
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            scrapper.GetSpareParts($"https://catcar.info/toyota/?lang=en&l=bWFya2V0PT1ldXJvfHxzdD09NzB8fHN0cz09eyIxMCI6IlJlZ2lvbiIsIjIwIjoiRXVyb3BlIiwiMzAiOiI0LVJVTk5FUiBUUlVDSyA2NzE0NDAiLCI2MCI6IkxONTFMLUtSQSIsIjcwIjoiMDktMDEgU1RBTkRBUkQgVE9PTCJ9fHxjYXRhbG9nPT02NzE0NDB8fHJlYz09QTF8fG1vZGlmbmFtZT09TE41MUwtS1JBfHxlbmdpbmU9PTJMfHxtb2RlbG5vPT0wMDF8fFByb2RQZXJpb2Q9PTE5ODQwODE5ODUwOHx8bW9kX2luZm8wPT1UMXx8bW9kX2luZm8xPT1TVER8fG1vZF9pbmZvMj09TVRNfHxtb2RfaW5mbzM9PTRGfHxtb2RfaW5mbzQ9PVJDQnx8bW9kX2luZm81PT1HfHxtb2RfaW5mbzY9PUhMRnx8bW9kX2luZm83PT1TVHx8bW9kX2luZm84PT1VU0F8fG1vZF9pbmZvOT09RFNMfHxtb2RfaW5mbzEwPT1DQlV8fHBhZ2U2MD09MDAxfHxncm91cF9pZD09MDkwMXx8cGFnZTcwPT0w");
        }

        //private void Btn6_Click(object sender, RoutedEventArgs e)
        //{
        //    //scrapper.GetAdditInfoSpareParts($"https://catcar.info/toyota/?lang=en&l=bWFya2V0PT1ldXJvfHxzdD09NzB8fHN0cz09eyIxMCI6IlJlZ2lvbiIsIjIwIjoiRXVyb3BlIiwiMzAiOiI0LVJVTk5FUiBUUlVDSyA2NzE0NDAiLCI2MCI6IkxONTFMLUtSQSIsIjcwIjoiMDktMDEgU1RBTkRBUkQgVE9PTCJ9fHxjYXRhbG9nPT02NzE0NDB8fHJlYz09QTF8fG1vZGlmbmFtZT09TE41MUwtS1JBfHxlbmdpbmU9PTJMfHxtb2RlbG5vPT0wMDF8fFByb2RQZXJpb2Q9PTE5ODQwODE5ODUwOHx8bW9kX2luZm8wPT1UMXx8bW9kX2luZm8xPT1TVER8fG1vZF9pbmZvMj09TVRNfHxtb2RfaW5mbzM9PTRGfHxtb2RfaW5mbzQ9PVJDQnx8bW9kX2luZm81PT1HfHxtb2RfaW5mbzY9PUhMRnx8bW9kX2luZm83PT1TVHx8bW9kX2luZm84PT1VU0F8fG1vZF9pbmZvOT09RFNMfHxtb2RfaW5mbzEwPT1DQlV8fHBhZ2U2MD09MDAxfHxncm91cF9pZD09MDkwMXx8cGFnZTcwPT0w");
        //}

        //private void ListModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (scrapper.ListCarModelsNamesSelectedInd != -1)
        //    {
        //        Btn2.IsEnabled = true;
        //    }
        //}        
    }
}
