using AutoMapper;
using DivingLogApi.Data;
using DivingLogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Services
{
    public class DiveService
    {
        private readonly DivingLogContext context;
        private readonly IMapper mapper;

        public DiveService(DivingLogContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        public async Task<ActionResult<IEnumerable<Dive>>> GetAllDives()
        {
            var allDives = context.Dives
                .Include(d => d.DiveSite)
                //.Include(d => d.Divers)   //uncoment if you decide to eager load '<UserDive> aka Divers'
                .ToListAsync();

            return await allDives;
        }

        public ActionResult<Dive> DiveEdit(Dive dive, int diveId)
        {
            var diveToEdit = context.Dives.Find(diveId);

            if (diveToEdit is null)
                return null;

            diveToEdit = mapper.Map(dive, diveToEdit);
            diveToEdit.DiveId = diveId;
             
            try
            {
                context.Entry(diveToEdit);
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return dive;
        }

        public async Task<bool> DeleteDive(int diveId)
        {
            var diveToRemove = context.Dives.Find(diveId);

            if (diveToRemove is null)
                return false;

            context.Dives.Remove(diveToRemove);

            try
            {
                context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return true;
        }
    }
}
