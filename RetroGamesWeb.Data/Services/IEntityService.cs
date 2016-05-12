﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetroGamesWeb.Data.Entities;

namespace RetroGamesWeb.Data.Services
{
    public interface IEntityService<T> where T : IMongoEntity
    {
        void Create(T entity);

        void Delete(string id);

        T GetById(string id);

        void Update(T entity);
    }
}
