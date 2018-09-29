using AutoMapper;
using OnlineExams.Models;
using OnlineExams.Models.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnlineExamApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TrainerCreateVM, Trainer>();
<<<<<<< HEAD
                cfg.CreateMap<Course,CourseEditVM>();
                cfg.CreateMap<CourseEditVM,Course>();
                cfg.CreateMap<CourseTrainerVM,CourseTrainer>();
                cfg.CreateMap<CourseTrainer, CourseTrainerVM>();
                //cfg.CreateMap<Trainer, TrainerCreateVM>();


=======
                //cfg.CreateMap<Trainer, TrainerCreateVM>();
               
                
>>>>>>> bec26b27843d4effc520e9a64f21d64bda4cf0ee
            });
        }
    }
}
