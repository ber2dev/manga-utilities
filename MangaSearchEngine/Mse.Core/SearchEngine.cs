using Mse.Core.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

namespace Mse.Core
{
   public sealed class SearchEngine
   {
      #region Constants

      public readonly static string MAIN_INTERFACE_NAME = typeof(MangaFinder).Name;

      #endregion

      #region Singleton

      private readonly static object INSTANCE_LOCK = new object();
      private volatile static SearchEngine _instance;

      public static SearchEngine Instance
      {
         get
         {
            if (_instance != null)
            {
               lock (INSTANCE_LOCK)
               {
                  if (_instance == null) _instance = new SearchEngine();
               }
            }

            return _instance;
         }
      }

      #endregion

      #region Constructors

      private SearchEngine()
      {
         _finders = new Dictionary<MangaFinderVersion, MangaFinder>();
      }

      #endregion

      #region Public

      public void RegisterFinder(MangaFinder pMangaFinder)
      {
         pMangaFinder.AssertNull("pMangaFinder");
         pMangaFinder.Version.AssertNull("pMangaFinder.Version");

         if (_finders.ContainsKey(pMangaFinder.Version))
         {
            return;
         }

         _finders.Add(pMangaFinder.Version, pMangaFinder);
      }

      public IEnumerable<MangaFinderItem> Search(string pSearchToken)
      {
         var list = new List<MangaFinderItem>();
         foreach(var finder in _finders.Values)
         {
            try
            {
               list.AddRange(finder.Find(pSearchToken));
            }
            catch (Exception ex)
            {
               Trace.TraceError(ex.Message);
            }
         }
         return list;
      }

      #endregion

      #region Private

      private readonly IDictionary<MangaFinderVersion, MangaFinder> _finders;

      private void Configure()
      {
         var assemblies = AppDomain.CurrentDomain.GetAssemblies();
         if (assemblies == null)
         {
            return;
         }

         foreach (var assembly in assemblies.Where(x => x != null))
         {
            var assemblyTypes = assembly.GetTypes();
            if (assemblyTypes == null)
            {
               continue;
            }

            foreach (var type in assemblyTypes.Where(x => x != null))
            {
               if (!HasFinderInterface(type))
               {
                  continue;
               }

               try
               {
                  CreateAndRegisterFinder(assembly, type);
               }
               catch (Exception ex)
               {
                  Trace.TraceError(ex.Message);
               }
            }
         }
      }

      private bool HasFinderInterface(Type pType)
      {
         var typeInterfaces = pType.GetInterfaces();
         if (typeInterfaces == null)
         {
            return false;
         }

         var matchingInterface = typeInterfaces.FirstOrDefault(x => MAIN_INTERFACE_NAME.Equals(x.Name));
         if (matchingInterface == null)
         {
            return false;
         }

         return true;
      }

      private void CreateAndRegisterFinder(Assembly pAssembly, Type pFinderType)
      {
         var mangaFinderInstance = pAssembly.CreateInstance(pFinderType.FullName) as MangaFinder;
         if (mangaFinderInstance != null)
         {
            RegisterFinder(mangaFinderInstance);
         }
      }

      #endregion
   }
}
