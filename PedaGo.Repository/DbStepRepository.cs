//-----------------------------------------------------------------------
// <copyright file="DbStepRepository.cs" company="Diiage">
//     SmartCity2020 - Team 4.
// </copyright>
//-----------------------------------------------------------------------

namespace PedaGo.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PedaGo.Entities;
    using PedaGo.EntityContext;
    using PedaGo.Repository.Contracts;

    /// <summary>
    /// Class to make the communication with the database for the steps
    /// </summary>
    public class DbStepRepository : IStepRepository
    {
        /// <summary>
        /// Scope factory interface
        /// </summary>
        private readonly IServiceScopeFactory scopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbStepRepository" /> class.
        /// </summary>
        /// <param name="scopeSrc">Scope factory interface</param>
        public DbStepRepository(IServiceScopeFactory scopeSrc)
        {
            this.scopeFactory = scopeSrc;
        }

        /// <summary>
        /// Method to add a step to the database
        /// </summary>
        /// <param name="step">Step object to add</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        bool IStepRepository.AddStep(Step step)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Steps.Add(step);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to insert multiple steps in the database
        /// </summary>
        /// <param name="steps">List of Step</param>
        /// <returns>Return a boolean if the insertion appends correctly</returns>
        bool IStepRepository.AddSteps(List<Step> steps)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Steps.AddRange(steps);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to delete a step in the database
        /// </summary>
        /// <param name="step">Step object to delete</param>
        /// <returns>Return a boolean if the suppression appends correctly</returns>
        bool IStepRepository.DeleteStep(Step step)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Steps.Remove(step);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to get a Step by its id from the database
        /// </summary>
        /// <param name="id">Id of the Step</param>
        /// <returns>Return a Step Object</returns>
        Step IStepRepository.GetStepById(int id)
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Steps.Where(s => s.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Method to get all the steps from the database
        /// </summary>
        /// <returns>return a IEnumerable of Steps</returns>
        IEnumerable<Step> IStepRepository.GetSteps()
        {
            return this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>().Steps;
        }

        /// <summary>
        /// Method to update a step in the database
        /// </summary>
        /// <param name="step">Step object to update</param>
        /// <returns>Return a boolean if the update appends correctly</returns>
        bool IStepRepository.UpdateStep(Step step)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    context.Steps.Update(step);
                    context.SaveChanges();
                }

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns current step of a given user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>APICurrentStep object</returns>
        APICurrentStep IStepRepository.GetCurrentStep(int id)
        {
            try
            {
                using (var context = this.scopeFactory.CreateScope().ServiceProvider.GetService<DatabaseContext>())
                {
                    var player = context.Players.FirstOrDefault(p => p.Id == id);

                    if (player != null)
                    {
                        var currentTeam = context.Teamroutes.Include(tr => tr.Team).Where(tr => tr.Team.Teamplayers.Any(p => p.PlayerId == id)).Where(tr => tr.ValidationDate == null).OrderBy(tr => tr.StepOrder).Select(tr => tr.Team).FirstOrDefault();

                        if (currentTeam != null)
                        {
                            var currentStep = context.Teamroutes.Include(tr => tr.Routestep).ThenInclude(rs => rs.Step).Include(tr => tr.Routestep).ThenInclude(rs => rs.Route).Where(tr => tr.TeamId == currentTeam.Id && tr.ValidationDate == null).OrderBy(tr => tr.StepOrder).FirstOrDefault().Routestep;

                            var routeName = currentStep.Route.Name;
                            var stepName = currentStep.Step.Name;
                            var stepDescription = currentStep.Step.Description;
                            var stepId = currentStep.StepId;

                            APICurrentStep apiCurrentStep = new APICurrentStep { RouteName = routeName, StepName = stepName, StepDescription = stepDescription, StepId = stepId };

                            return apiCurrentStep;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
