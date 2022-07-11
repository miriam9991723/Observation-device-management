using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Entities;

namespace DalXML
{
    public partial class DalXML
    {
        string devicesListFilePath = @"..\..\..\..\DAL\DalXML\ObservationDevices.xml";
        string configFilePath = @"..\..\..\..\DAL\DalXML\config.xml";
        public int AddDevice(DeviceType type, int range, float fieldOfVision)
        {
            int id = getIdIntilizer();
            try
            {
                List<ObservationDevice> deviceList = XMLTools.LoadListFromXMLSerializer<ObservationDevice>(devicesListFilePath).ToList();
                deviceList.Add(new ObservationDevice(id, type, range, fieldOfVision));
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

            setIdIntilizer(id + 1);
            return id;
        }

        public IEnumerable<ObservationDevice> GetDevices(Predicate<ObservationDevice> getBy = null)
        {
            IEnumerable<ObservationDevice> deviceList = XMLTools.LoadListFromXMLSerializer<ObservationDevice>(devicesListFilePath);

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

        int getIdIntilizer()
        {
            XElement config = XMLTools.LoadData(configFilePath);
            return Int32.Parse( config.Element("idIntelizer").Value);
        }

        void setIdIntilizer(int value)
        {
            XElement config = XMLTools.LoadData(configFilePath);
            config.Element("idIntelizer").Value = value.ToString();
            config.Save(configFilePath);
        }


    }
}
