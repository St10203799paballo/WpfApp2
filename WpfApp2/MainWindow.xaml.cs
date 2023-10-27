using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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



namespace WpfApp2
{
   
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> userAccounts = new Dictionary<string, string>();
        private List<Module> modules = new List<Module>();
        //windows link 
        private NavigationService navigationService;
        public MainWindow()
        {
            InitializeComponent();
            this.navigationService = NavigationService.GetNavigationService(this);
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {

            string code = ModuleCode.Text;
            string name = ModuleName.Text;
            double credits = double.Parse(ModuleCredits.Text);
            double week = double.Parse(ModuleWeekHours.Text);
            double hours = double.Parse(ModuleHours.Text);

            double study = (credits * 10) / week;

            Module module = new Module(code, name, credits, hours);
            modules.Add(module);

           
            double weeks = 16; 

            ResultText.Text = "Modules details with hours:\n";
            foreach (Module m in modules)
            {
                ResultText.Text += $"\nCode: {m.Code}\n";
                ResultText.Text += $"Name: {m.Name}\n";
                ResultText.Text += $"Credits: {m.Credits}\n";
                ResultText.Text += $"Weeks: {weeks}\n";
                ResultText.Text += $"Hours: {m.Hours:F2}\n";
            }

            ResultText.Text += "\nHours Remaining:\n";
            foreach (Module m in modules)
            {
                double hoursRemainingForModule = m.Hours * weeks / m.Credits;
                ResultText.Text += $"{m.Name}: {hoursRemainingForModule:F2} hours remaining\n";
            }


        }
        
        public class Module
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public double Credits { get; set; }
            public double Hours { get; set; }

            public Module(string code, string name, double credits, double hours)
            {
                Code = code;
                Name = name;
                Credits = credits;
                Hours = hours;
            }
        }

        AddModuleWindow addModuleWindow = new AddModuleWindow();
        //addModuleWindow.modulesCopy.AddRangeCmodules);
        addModuleWindow.Show();

    }
}

