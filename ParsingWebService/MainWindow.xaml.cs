using Newtonsoft.Json;
using ParsingWebService.Class;
using System.Windows;



namespace ParsingWebService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Request request = new NumberRequest
                ("http://api.weatherbit.io/v2.0/current?lat=54.4312&lon=20.3000&key=1410135329d74feca4694bf87e711b70&include=minutely");//Создание запроса с сервиса NUmber
            Data dataNumber = request.Create();//Создание класса данных 
            dataNumber = new NumberData();//Создание класса данных с сервиса Number
            string testString;
            request.Run();//Выполнение запроса
            testString = request.Responce;

            ListBoxDataVebParsing.Items.Add(testString);
            lb.Content = request.Responce;//Вывод результат запроса в Label

            Test test= Newtonsoft.Json.JsonConvert.DeserializeObject<Test>(testString);

            //lb.Content= test.rh.ToString();
            //lb.Content=test.temp.ToString();
            ListBoxDataVebParsing.Items.Add(test.rh);
            ListBoxDataVebParsing.Items.Add(test.temp);
        }


    }
}
