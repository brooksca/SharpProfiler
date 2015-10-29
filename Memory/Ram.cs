﻿using Sharp_Profiler.Hardware;
using System;
using System.Collections.Generic;

namespace Sharp_Profiler.Memory
{
    class Ram : Component
    {
        /// <summary>
        /// Gets all of the physically labeled banks where the memory is located
        /// </summary>
        /// <returns>Bank labels</returns>
        public List<object> getBankLabels()
        {
            try
            {
                return this.queryWmi("SELECT BankLabel FROM Win32_PhysicalMemory", "BankLabel", 0);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the total capacity of the system's physical memory
        /// </summary>
        /// <returns>Total capacity of the physical memory</returns>
        public UInt64? getCapacity()
        {
            try
            {
                UInt64 size = 0;
                List<object> capacities = this.queryWmi("SELECT Capacity FROM Win32_PhysicalMemory", "Capacity", 0);
                foreach (UInt64 item in capacities)
                {
                    size += item;
                }
                size = size / 1024 / 1024;
                return size;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the memory data width in bits
        /// </summary>
        /// <returns>Memory data width</returns>
        public UInt16? getDataWidth()
        {
            try
            {
                return (UInt16)this.queryWmi("SELECT DataWidth FROM Win32_PhysicalMemory", "DataWidth");
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the description of the object
        /// </summary>
        /// <returns>Description</returns>
        public string getDescription()
        {
            try
            {
                return (string)this.queryWmi("SELECT Description FROM Win32_PhysicalMemory", "Description");
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the name of the socket or circuit board that holds the memory
        /// </summary>
        /// <returns>Label of the socket or circuit board</returns>
        public string getDeviceLocation()
        {
            try
            {
                return (string)this.queryWmi("SELECT DeviceLocator FROM Win32_PhysicalMemory", "DeviceLocator");
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
