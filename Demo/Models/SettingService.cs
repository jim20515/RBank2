using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Demo.Models
{
    public class Setting
    {
        public string Name { get; set; }
        public string Value { get; set; }
        //public string Category { get; set; }
    }

    /// <summary>
    /// Stores the Setting data in a json file so that no database is required for this
    /// </summary>
    public class SettingService
    {
        private static string filePath = HostingEnvironment.MapPath(@"~/App_Data/Settings.json");
        private List<Setting> _settings = JsonConvert.DeserializeObject<List<Setting>>(File.ReadAllText(filePath));

        /// <summary>
        /// list all of settings.
        /// </summary>
        /// <returns>list</returns>
        internal List<Setting> List()
        {
            return _settings;
        }

        /// <summary>
        /// get value by name. return empty string when name not exist.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>string</returns>
        internal string Get(string name)
        {
            var i = _settings.FindIndex(p => p.Name == name);

            if (i > -1)
            {
                return _settings[i].Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Create an New setting. return false when name has exist.
        /// </summary>
        /// <param name="Setting model"></param>
        /// <returns>bool</returns>
        internal bool Create(Setting model)
        {
            if (model.Name == null) return false;

            // Locate and replace the item
            var i = _settings.FindIndex(p => p.Name == model.Name);

            if (i == -1)
            {
                _settings.Add(model);
                return Save(_settings);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Update an exist Name. return false when name not exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        internal bool SetName(string name, string value)
        {
            // Locate and replace the item
            var i = _settings.FindIndex(p => p.Name == name);

            if (i > -1)
            {
                _settings[i].Name = value;
                return Save(_settings);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Update an exist setting or Create an not not exist setting.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        internal bool SetValue(string name, string value)
        {
            // Locate and replace the item
            var i = _settings.FindIndex(p => p.Name == name);

            if (i > -1)
            {
                _settings[i].Value = value;
                return Save(_settings);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Delete an exist setting. return false when name not exist.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>bool</returns>
        internal bool Delete(string name)
        {
            var i = _settings.FindIndex(p => p.Name == name);
            if (i > -1)
            {
                _settings.RemoveAt(i);
                Save(_settings);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Save(List<Setting> settings)
        {
            try
            {
                // Write out the Json
                var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(filePath, json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}