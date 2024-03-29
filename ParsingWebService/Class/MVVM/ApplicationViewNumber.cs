﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using ParsingWebService.Class.MVVM;
using ParsingWebService.Class.Команды;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;

namespace ParsingWebService.Class
{
    public class ApplicationViewNumber:INotifyPropertyChanged
    {
        private static WindowInputDate windowInputDate = null;
        DispatcherTimer timer = new DispatcherTimer();
        public string day { get; set; }
        public string month { get; set; }
        private NumberRequest selectedNumber;
        private  NumberData selectedData;
        public ObservableCollection<NumberData> NumberDataCollection { get; set; }
        public ObservableCollection<NumberRequest> thisTimes { get; set; }
        //Событие таймер
        private void timer_Tick(object sender, EventArgs e)
        {
            day = new Random().Next(1, 28).ToString();
            month = new Random().Next(1, 12).ToString();
            NumberRequest newRequest = new NumberRequest
            ($"http://numbersapi.com/{month}/{day}/date");

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
        }

        //Команда додавления нового результата запроса

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      day=new Random().Next(1,28).ToString();
                      month=new Random().Next(1,12).ToString();
                      NumberRequest newRequest = new NumberRequest
                      ($"http://numbersapi.com/{month}/{day}/date");

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
            get { return selectedData; }
            set
            {
                SelectedData = value;
                OnPropertyChanged("SelectedRequest");
            }
        }
        //Запуск автономного парсинга 
        private RelayCommand autoAddCommand;
        public RelayCommand AutoAddCommand
        {
            get
            {

                return autoAddCommand ??
                    (autoAddCommand = new RelayCommand(obj =>
                    {
                        
                        timer.Tick += new EventHandler(timer_Tick);
                        timer.Interval = new TimeSpan(0, 0, 1);
                        timer.Start();
                    }));
            }
        }

        //Остановка автономго парсинга
        private RelayCommand stopAutoAddCommand;
        public RelayCommand StopAutoAddCommand
        {
            get
            {

                return stopAutoAddCommand ??
                    (stopAutoAddCommand = new RelayCommand(obj =>
                    {
                        timer.Stop();
                    }));
            }
        }


        // Вывод истории парсинга на экран
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


        //Ввод даты
        private RelayCommand inputDate;
        public RelayCommand InputDate
        {
            get
            {
                return inputDate ??
                    (inputDate = new RelayCommand(obj =>
                    {
                        windowInputDate = new WindowInputDate(this);
                        windowInputDate.showDateWindow();

                    }));
            }
        }

        //Добавить результата по введенным днем и месяц
        private RelayCommand addCommandInput;
        public RelayCommand AddCommandInput
        {

            get
            {
                return addCommandInput ??
                  (addCommandInput = new RelayCommand(obj =>
                  {

                      NumberRequest newRequest = new NumberRequest
                      ($"http://numbersapi.com/{month}/{day}/date");

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
        //Отменить ввод даты
        private RelayCommand cancelDate;
        public RelayCommand CancelDate
        {
            get
            {
                return cancelDate ??
                    (cancelDate = new RelayCommand(obj =>
                    {
              
                        windowInputDate?.cancelDateWindow();

                    }));
            }
        }
        //Конструктор ViewModel
        public ApplicationViewNumber()
        {
            NumberDataCollection = new ObservableCollection<NumberData>
            {
              
            };
            MessageBox.Show("hello");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    
}
