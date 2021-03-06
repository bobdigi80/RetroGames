﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using RetroGamesWeb.Data.Entities;

namespace RetroGamesWeb.Data
{
    public class MongoConnectionHandler<T> where T : IMongoEntity
    {
        public IMongoCollection<T> MongoCollection { get; private set; }

        public MongoConnectionHandler()
        {
            const string connectionString = "mongodb://localhost";

            //// Get a thread-safe client object by using a connection string
            var mongoClient = new MongoClient(connectionString);
            
            //// Get a reference to the "retrogamesweb" database object 
            //// from the Mongo server object
            const string databaseName = "retrogamesweb";
            var db = mongoClient.GetDatabase(databaseName);

            //// Get a reference to the collection object from the Mongo database object
            //// The collection name is the type converted to lowercase + "s"
            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }
    }
}
