using MMORPGServer.Entity;

namespace Service
{
    public class DBService : Singleton<DBService>
    {
        DatabaseConnection entities;



        public DatabaseConnection Entities
        {
            get { return this.entities; }
        }

        public void Init()
        {
            entities = new DatabaseConnection();
        }

        //public void save(bool async = false)
        //{
        //    if (async)
        //        entities.savechangesasync();
        //    else
        //        entities.savechanges();
        //}
    }
}
