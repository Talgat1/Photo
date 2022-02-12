using SQLite;
using System;
using System.Collections.Generic;
using Photo.DataPhoto;
using System.Text;

namespace Photo.DB
{
    public class CRUDOperation
    {
        SQLiteConnection db;
        public CRUDOperation(string databasePath)
        {
            db = new SQLiteConnection(databasePath);
            db.CreateTable<PhotoCopy>();
        }
        public IEnumerable<PhotoCopy> GetProjects()
        {
            return db.Table<PhotoCopy>();
        }
        public int SaveItem(PhotoCopy photo)
        {
            if (photo.Id != 0)
            {
                db.Update(photo);
                return photo.Id;
            }
            else
            {
                return db.Insert(photo);
            }
        }

    }
}
