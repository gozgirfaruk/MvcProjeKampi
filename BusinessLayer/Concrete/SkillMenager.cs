using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class SkillMenager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillMenager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }
    }
}
