using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace ParsingWebService.Class.MVVM
{
   /* public class ApplicationViewWeather: INotifyPropertyChanged
    {
        private NumberRequest selectedNumber;
        private NumberData selectedData;
        public ObservableCollection<NumberData> NumberDataCollection { get; set; }
        public ObservableCollection<NumberRequest> thisTimes { get; set; }

        //Команда додавления нового результата запроса

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {

            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {                      
                      NumberRequest newRequest = new NumberRequest
                  ("http://api.weatherbit.io/v2.0/current?lat=54.4312&lon=20.3000&key=1410135329d74feca4694bf87e711b70&include=minutely");

                      //Десириализация данных
                      JObject json = JObject.Parse(newRequest.Responce);
                      JsonData data=new JsonData();
                      Test test = Newtonsoft.Json.JsonConvert.
                      DeserializeObject<Test>(json["data"].First.ToString());


                      //Добавление в базу данных
                      using (NumberContext db = new NumberContext())
                      {
                          NumberData myData = new NumberData
                          { outputRuquest = newRequest.Responce, thisTime = DateTime.Now };
                          NumberDataCollection.Add(myData);
                          selectedData = myData;
                          db.Numbers.Add(myData);
                          db.SaveChanges();
                      }


                  }));
            }
        }
        public NumberRequest SelectedNumber
        {
            get { return selectedNumber; }
            set
            {
                selectedNumber = value;
                OnPropertyChanged("SelectedRequest");
            }
        }
        public NumberData SelectedData
        {
            get { return SelectedData; }
            set
            {
                SelectedData = value;
                OnPropertyChanged("SelectedRequest");
            }
        }
        //Команда вывода истории на экран
        private RelayCommand showDB;
        public RelayCommand ShowDB
        {
            get
            {
                return showDB ??
                    (showDB = new RelayCommand(obj =>
                    {
                        using (NumberContext db = new NumberContext())
                        {
                            var numbersData = db.Numbers;
                            NumberDataCollection.Clear();

                            foreach (NumberData data in numbersData)
                            {
                                NumberDataCollection.Add(data);
                                //NumberRequest numberRequestData = new NumberRequest();
                                //NumberRequests.Add(data.outputRuquest);
                            }
                        }

                    }));
            }
        }

        //Конструктор ViewModel
        public ApplicationViewNumber()
        {
            NumberDataCollection = new ObservableCollection<NumberData>
            {

            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

*/
}

