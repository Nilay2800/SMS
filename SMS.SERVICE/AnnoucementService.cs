using SMS.Data;
using SMS.Data.Database;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
    public class AnnoucementService
    {
        public readonly AnnoucementProvider annocementProvider;
        public AnnoucementService()
        {
            annocementProvider = new AnnoucementProvider();
        }
        public List<AnnoucementModel> GetAllAnnoucement()
        {
            var annoucement = annocementProvider.GetAllAnnoucement();
            return annoucement;
        }
        public Annoucement CreateAnnoucement(AnnoucementModel annoucementModel)
        {
            return annocementProvider.CreateAnnoucement(annoucementModel);
        }
        public AnnoucementModel UpdateAnnoucement(AnnoucementModel annoucementModel)
        {
            return annocementProvider.UpdateAnnoucement(annoucementModel);
        }
        public AnnoucementModel GetAnnocementById(int id)
        {
            var data = annocementProvider.GetAnnoucementById(id);
            AnnoucementModel annoucementModel = new AnnoucementModel
            {
                Id = data.Id,
                AnnoucementDetail=data.AnnoucementDetail,
                CreatedOn = data.CreatedOn

            };
            return annoucementModel;
        }
        public void DeleteAnnoucement(int Id)
        {
            annocementProvider.DeleteAnnoucement(Id);
        }

    }
}
