using SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Data
{
    public class AnnoucementProvider:BaseProvider
    {
        public AnnoucementProvider()
        {

        }
        public List<AnnoucementModel> GetAllAnnoucement()
        {
            return _db.annoucements.Select(x => new AnnoucementModel
            {
                Id = x.Id,
                Subject = x.Subject,
                AnnoucementDetail = x.AnnoucementDetail,
                CreatedOn = x.CreatedOn
               
            }).ToList();
        }
        public Annoucement GetAnnoucementById(int Id)
        {
            return _db.annoucements.Find(Id);
        }
        public Annoucement CreateAnnoucement(AnnoucementModel annoucementModel)
        {
            Annoucement _annocement = new Annoucement()
            {
                Id = annoucementModel.Id,
                Subject = annoucementModel.Subject,
                AnnoucementDetail=annoucementModel.AnnoucementDetail,
                CreatedOn = DateTime.UtcNow
                
            };

            _db.annoucements.Add(_annocement);
            _db.SaveChanges();

            return _annocement;
        }

        public AnnoucementModel UpdateAnnoucement(AnnoucementModel annoucementModel)
        {
            var objannocement = GetAnnoucementById(annoucementModel.Id);
            objannocement.Subject = annoucementModel.Subject;
            objannocement.AnnoucementDetail = annoucementModel.AnnoucementDetail;
            objannocement.CreatedOn = annoucementModel.CreatedOn;
          _db.SaveChanges();
            return annoucementModel;
        }
        public void DeleteAnnoucement(int Id)
        {
            var data = GetAnnoucementById(Id);
            if (data != null)
            {
                _db.annoucements.Remove(data);
                _db.SaveChanges();
            }
        }

    }
}
