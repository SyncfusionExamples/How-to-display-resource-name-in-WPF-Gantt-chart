#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Syncfusion.Windows.Controls.Gantt;
using System.Windows;
using System.Windows.Media;

namespace Gantt_GettingStarted
{
    public class ViewModel
    {
        /// <summary>
        /// private field for team details
        /// </summary>
        private ObservableCollection<Item> teamDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.teamDetails = this.GetTeamInfo();
        }

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<Item> TeamDetails
        {
            get
            {
                return this.teamDetails;
            }

            set
            {
                this.teamDetails = value;
            }
        }

        /// <summary>
        /// Gets the team info.
        /// </summary>
        /// <returns>returns the team info</returns>
        public ObservableCollection<Item> GetTeamInfo()
        {
            ObservableCollection<Item> teams = new ObservableCollection<Item>();

            teams.Add(new Item() { Name = "RDU Team" });
            Item Person = new Item() { Name = "Robert" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 16, 12, 0, 0), FinishDate = new DateTime(2012, 01, 16, 12, 0, 0), Name = "Design Spec" });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 17, 12, 0, 0), FinishDate = new DateTime(2012, 01, 21), Name = "Design Spec" });
            teams[0].SubItems.Add(Person);

            Person = new Item() { Name = "Michael" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 19, 12, 0, 0), FinishDate = new DateTime(2012, 01, 23), Name = "Requirement Spec" });
            teams[0].SubItems.Add(Person);



            teams.Add(new Item() { Name = "Graphics Team" });
            Person = new Item() { Name = "Madhan" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 21, 12, 0, 0), FinishDate = new DateTime(2012, 01, 26), Name = "Defining UI Design" });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 27), FinishDate = new DateTime(2012, 02, 5), Name = "Completing Overall Graphics design" });

            teams[1].SubItems.Add(Person);

            Person = new Item() { Name = "Peter" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 24, 12, 0, 0), FinishDate = new DateTime(2012, 01, 28), Name = "Completing Overall Graphics design" });
            teams[1].SubItems.Add(Person);


            teams.Add(new Item() { Name = "Dev Team" });
            Person = new Item() { Name = "Ruban" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 26, 12, 0, 0), FinishDate = new DateTime(2012, 01, 30), Name = "Development Plan", Progress = 10 });
            teams[2].SubItems.Add(Person);

            Person = new Item() { Name = "Karthick" };
           Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 29, 12, 0, 0), FinishDate = new DateTime(2012, 02, 2), Name = "Self Testing" });
            teams[2].SubItems.Add(Person);


           //Adding resources to the last InLine Item.
            for (int i = 0; i < teams.Count; i++)
            {
                for (int j = 0; j < teams[i].SubItems.Count; j++)
                {
                    int count = teams[i].SubItems[j].InLineItems.Count;
                    string name = teams[i].SubItems[j].Name;
                    teams[i].SubItems[j].InLineItems[count - 1].Resource.Add(new Resource()
                    {
                        Name = name
                    });
                }
            }
            return teams;
        }
    }
}
