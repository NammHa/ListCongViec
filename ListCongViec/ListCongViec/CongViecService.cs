using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ListCongViec
{
    class CongViecService
    {
        public ObservableCollection<CongViec> cvService { get; set; }

        public CongViecService()
        {
            cvService = new ObservableCollection<CongViec>();
        }
        public async Task<bool> UpdateEmployeeAsync(CongViec cv)
        {
            CongViec employeeToEdit = cvService.Where(x => x.ID == x.ID).FirstOrDefault();

            int newIdex = cvService.IndexOf(employeeToEdit);
            cvService.Remove(employeeToEdit);

            cvService.Add(cv);
            int oldIndex = cvService.IndexOf(cv);

            cvService.Move(oldIndex, newIdex);

            return await Task.FromResult(true);
        }
        public async Task<ObservableCollection<CongViec>> GetEmployeesAsync(string query)
        {
            //Thread.Sleep(2000);

            if (query != string.Empty)
            {
                cvService.Clear();
                //InitializeEmployeeService();
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);

                var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListCV");
                string listCVJSON = await response.Content.ReadAsStringAsync();
                listCV cvobj = new listCV();
                cvobj = JsonConvert.DeserializeObject<listCV>(listCVJSON);
                IList<CongViec> cv = new List<CongViec>();
                cv = cvobj.DATA;
                foreach (var item in cv)
                {

                    switch (item.ID_KET_QUA_CV)
                    {
                        case 1:
                            item.KET_QUA_CV = "Hoàn thành";
                            break;
                        case 2:
                            item.KET_QUA_CV = "Hủy";
                            break;
                        case 3:
                            item.KET_QUA_CV = "Đang làm";
                            break;
                        default:
                            item.KET_QUA_CV = "";
                            break;
                    }
                }
                List<CongViec> llstCVes = cvService.Where(x => (x.TEN_CONG_VIEC.ToLower().Contains(query.ToLower())
                                                                    || x.TEN_CONG_VIEC.ToLower().Contains(query.ToLower()))).ToList();

                cvService.Clear();
                foreach (CongViec def in llstCVes)
                {
                    cvService.Add(def);
                }

            }
            else
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);

                var response = await client.GetAsync("https://qlcv-api.conveyor.cloud/api/GetListCV");
                string listCVJSON = await response.Content.ReadAsStringAsync();
                listCV cvobj = new listCV();
                cvobj = JsonConvert.DeserializeObject<listCV>(listCVJSON);
                IList<CongViec> cv = new List<CongViec>();
                cv = cvobj.DATA;
                foreach (var item in cv)
                {

                    switch (item.ID_KET_QUA_CV)
                    {
                        case 1:
                            item.KET_QUA_CV = "Hoàn thành";
                            break;
                        case 2:
                            item.KET_QUA_CV = "Hủy";
                            break;
                        case 3:
                            item.KET_QUA_CV = "Đang làm";
                            break;
                        default:
                            item.KET_QUA_CV = "";
                            break;
                    }
                }
                //InitializeEmployeeService();
            }
            return await Task.FromResult(cvService);
        }
    }
}
