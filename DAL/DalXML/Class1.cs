/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Entities;

namespace Dal
{
    public partial class DalXML
    {
        string devicesListFilePath = @"C:\Users\yebsc\source\repos\Observation-device-management\DAL\DalXML\ObservationDevices.xml";
        string configFilePath = @"..\..\..\..\DAL\DalXML\config.xml";
        public int AddDevice(DeviceType type, int range, float fieldOfVision)
        {
            int id = getIdIntilizer();
            XElement elements = XMLTools.LoadData(devicesListFilePath);
            XElement Id = new XElement("Id", id);
            XElement Type = new XElement("Type", type);
            XElement Range = new XElement("Range", range);
            XElement FieldOfVision = new XElement("FieldOfVision", fieldOfVision);
            elements.Add(new XElement("device", Id, Type, Range, FieldOfVision));
            elements.Save(devicesListFilePath);
            setIdIntilizer(id + 1);
            return id;

        }

        public IEnumerable<ObservationDevice> GetDevices(Predicate<ObservationDevice> getBy = null)
        {
            XElement elements = XMLTools.LoadData(devicesListFilePath);
            IEnumerable<ObservationDevice> deviceList;
            try
            {
                deviceList = (from p in elements.Elements()
                              select new ObservationDevice()
                              {
                                  Id = Convert.ToInt32(p.Element("Id").Value),
                                  Type = Convert.ToInt32(p.Element("Name").Value),
                                  Range = Convert.ToInt32(p.Element("Range").Value),
                                  FieldOfVision = Convert.ToDouble(p.Element("FieldOfVision").Value),
                                  Longitude = Convert.ToDouble(p.Element("Longitude").Value)
                              });
            }
            catch
            { }

            getBy ??= ((st) => true);

            return from station in StationList
                   where getBy(station)
                   select station;

            getBy ??= (device => true);
            return (from device in deviceList
                    where getBy(device)
                    select device);
        }

        public void RemoveDevice(int id)
        {
            try
            {
                List<ObservationDevice> deviceList = XMLTools.LoadListFromXMLSerializer<ObservationDevice>(devicesListFilePath).ToList();
                ObservationDevice device = deviceList.Find(device => device.Id == id);
                bool success = deviceList.Remove(device);
                if (!success) throw new KeyNotFoundException();
                XMLTools.SaveListToXMLSerializer(deviceList, devicesListFilePath);
            }
            catch (FieldAccessException)
            {
                throw;
            }
            catch (RankException)
            {
                throw;
            }

        }

        public static XElement LoadData(string filePath)
        {
            try
            {
                return XElement.Load(filePath);
            }
            catch
            {
                throw new FileNotFoundException(filePath);
            }
        }

        int getIdIntilizer()
        {
            XElement config = XMLTools.LoadData(configFilePath);
            return Int32.Parse(config.Element("idIntelizer").Value);
        }

        void setIdIntilizer(int value)
        {
            XElement config = XMLTools.LoadData(configFilePath);
            config.Element("idIntelizer").Value = value.ToString();
            config.Save(configFilePath);
        }


    }
}
*/