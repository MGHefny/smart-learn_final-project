using SmartLearn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLearn.Services
{
    public interface ITrainerService
    {
        // Trainer service
        int Create(Trainer trainer);
        Trainer FindByEmail(string email);
        Trainer ReadById(int Id);
        IEnumerable<Trainer> ReadAll();
    }
    public class TrainerService : ITrainerService
    {
        private readonly Courses_DBEntities db;
        public TrainerService()
        {
            db = new Courses_DBEntities();
        }
        public int Create(Trainer trainer)
        {
            var existsTrainer = FindByEmail(trainer.Email);
            if(existsTrainer != null)
            {
                return -2;
            }

            trainer.Creation_Date = DateTime.Now;
            db.Trainers.Add(trainer);
            return db.SaveChanges();

        }

        public Trainer FindByEmail(string email)
        {
            return db.Trainers.Where(t => t.Email == email).FirstOrDefault();
        }

        public IEnumerable<Trainer> ReadAll()
        {
            return db.Trainers;
        }

        public Trainer ReadById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}