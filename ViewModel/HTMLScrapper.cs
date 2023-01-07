using HtmlAgilityPack;
using ABP_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Windows;

namespace ABP_Test.ViewModel
{
    public class HTMLScrapper
    {
        private List<int> tempId;
        HtmlWeb web = new HtmlWeb();

        public ObservableCollection<string> CarModelsNames { get; set; }
        public ObservableCollection<string> ComplectationsBody { get; set; }
        public ObservableCollection<string> GroupPartsNames { get; set; }
        public ObservableCollection<string> SubGroupNames { get; set; }
        public ObservableCollection<string> SparePartNames { get; set; }       

        public HTMLScrapper()
        {
            tempId = new List<int>();
            CarModelsNames = new ObservableCollection<string>();
            ComplectationsBody = new ObservableCollection<string>();
            GroupPartsNames = new ObservableCollection<string>();
            SubGroupNames = new ObservableCollection<string>();
            SparePartNames = new ObservableCollection<string>();            
        }

        //Page1
        public void GetListCarModelAndCodes(string url)
        {
            var document = web.Load(url);
            var listFromPage1 = document.DocumentNode.SelectNodes("//*[@class = 'table__td']").Take(12).ToList();
            List<string> temp = new List<string>();
            try
            {
                using (MyDBContext m_db = new())
                {
                    for (int i = 0, j = 0; i < listFromPage1.Count; i++, j++)
                    {
                        temp.Add(listFromPage1[i].InnerText);
                        if (j == 3)
                        {
                            var mCarModel = new CarModel
                            {
                                Name = temp[1],
                                Code = temp[0],
                                ManufactureDate = temp[2],
                                Series = temp[3],
                            };
                            CarModelsNames.Add(mCarModel.Name);
                            m_db.CarModels.Add(mCarModel);
                            m_db.SaveChanges();
                            tempId.Add(mCarModel.Id);
                            j = -1;
                            temp.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Page2
        //for 1 element in page1
        public void GetListComplectations(string url)
        {
            int tmp = tempId[0];
            tempId.Clear();
            char[] delims = new[] { '\r', '\n' };
            var web = new HtmlWeb();
            var document = web.Load(url);
            var listFromPage2 = document.DocumentNode.SelectNodes("//*[@class = 'table__td']").Take(20).ToList();
            try
            {
                using (MyDBContext m_db = new())
                {
                    for (int i = 0, j = 0; i < listFromPage2.Count; i++, j++)
                    {
                        if (j == 3)
                        {
                            var lstStr = listFromPage2[i].InnerText.Trim('"').Split(delims, StringSplitOptions.RemoveEmptyEntries);
                            var mComplect = new Complectation
                            {
                                Body = lstStr[1].Trim(),
                                FuelInduction = lstStr[3].Trim(),
                                BuildingCondition = lstStr[5].Trim(),
                                Grade = lstStr[7].Trim(),
                                Transmission = lstStr[9].Trim(),
                                GearShiftType = lstStr[11].Trim(),
                                Cab = lstStr[13].Trim(),
                                TransmissionModel = lstStr[15].Trim(),
                                LoadingCapacity = lstStr[17].Trim(),
                                RearTide = lstStr[19].Trim(),
                                Destination = lstStr[21].Trim(),
                                CarModelID = tmp
                            };
                            ComplectationsBody.Add(mComplect.Body);
                            m_db.Complectations.Add(mComplect);
                            m_db.SaveChanges();
                            tempId.Add(mComplect.Id);
                            j = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Page3
        // for the first item only
        public void GetGroupParts(string url)
        {
            int tmp = tempId[0];
            tempId.Clear();
            var document = web.Load(url);
            var listFromPage3 = document.DocumentNode.SelectSingleNode("//*[@class = 'tabs']").ChildNodes;
            try
            {
                using (MyDBContext m_db = new())
                {
                    for (int i = 0; i < listFromPage3.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            var mGroupPart = new GroupParts
                            {
                                Name = listFromPage3[i].InnerText,
                                ComplectationID = tmp,
                            };
                            GroupPartsNames.Add(mGroupPart.Name);
                            m_db.GroupParts.Add(mGroupPart);
                            m_db.SaveChanges();
                            tempId.Add(mGroupPart.Id);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Page4
        public void GetSubgroups(string url)
        {
            int tmp = tempId[0];
            tempId.Clear();
            var document = web.Load(url);
            var listFromPage4 = document.DocumentNode.SelectNodes("//*[@class = 'groups-parts__title']");
            try
            {
                using (MyDBContext m_db = new())
                {
                    for (int i = 0; i < listFromPage4.Count; i++)
                    {
                        var mSubGroup = new SubGroup
                        {
                            Name = listFromPage4[i].InnerText,
                            GroupPartsID = tmp
                        };
                        SubGroupNames.Add(mSubGroup.Name);
                        m_db.SubGroups.Add(mSubGroup);
                        m_db.SaveChanges();
                        tempId.Add(mSubGroup.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Page5
        public void GetSpareParts(string url)
        {
            int tmp = tempId[0];
            tempId.Clear();
            var document = web.Load(url);
            List<string> Lsttemp = new List<string>();
            var listFromPage5 = document.DocumentNode.SelectNodes("//*[@class = 'table__td']");
            try
            {
                using (MyDBContext m_db = new())
                {
                    for (int i = 0, j = 0; i < listFromPage5.Count; i++, j++)
                    {
                        if (i % 2 == 0)
                        {
                            Lsttemp.Add(listFromPage5[i].InnerText);
                        }
                        else
                        {
                            Lsttemp.Add(listFromPage5[i].InnerText);
                        }
                        if (j == 1)
                        {
                            var mSparePart = new SparePart
                            {
                                Code = Lsttemp[0],
                                Name = Lsttemp[1],
                                SubGroupID = tmp
                            };
                            SparePartNames.Add(mSparePart.Name);
                            m_db.SpareParts.Add(mSparePart);
                            m_db.SaveChanges();
                            Lsttemp.Clear();
                            j = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

    }
}
