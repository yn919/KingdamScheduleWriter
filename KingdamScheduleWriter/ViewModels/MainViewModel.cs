using System;
using System.Collections.Generic;
using System.Text;
using KingdamScheduleWriter.Models;

namespace KingdamScheduleWriter.ViewModels
{
    class MainViewModel
    {
        private MainModel InnerModel;

        public MainViewModel()
        {
            InnerModel = new MainModel();
        }

        public void Start()
        {
            InnerModel.Start();
        }

        public void End()
        {
            InnerModel.End();
        }
    }
}
