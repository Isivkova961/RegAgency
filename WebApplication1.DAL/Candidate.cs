using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecrutmentAgency.Data
{
    public class Candidate
    {
        public virtual long Id { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Patronymic { get; set; }
        public virtual DateTime DateBirth { get; set; }
        public virtual string Experience { get; set; }
        public virtual PhotoFile FileId { get; set; }
        public virtual User UserId { get; set; }
    }

    public class CandidateMap: ClassMap<Candidate>
    {
        public CandidateMap()
        {
            Id(f => f.Id);
            Map(f => f.LastName);
            Map(f => f.FirstName);
            Map(f => f.Patronymic);
            Map(f => f.DateBirth);
            Map(f => f.Experience);
            References(f => f.FileId).Column("PhotoFileId").Cascade.SaveUpdate();
            References(f => f.UserId).Column("UserId").Cascade.SaveUpdate();
        }
    }
}
