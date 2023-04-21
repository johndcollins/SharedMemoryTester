using F4SharedMem;
using F4SharedMem.Headers;
using SharedMemoryTester.UI.BMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SharedMemoryTester.UI
{
    public partial class SharedMemoryForm : Form
    {
        Writer _sharedMemoryWriter = null;
        SharedMemorySample _sample = new SharedMemorySample();

        public SharedMemoryForm()
        {
            InitializeComponent();
        }

        private void SharedMemoryForm_Load(object sender, EventArgs e)
        {
            _sharedMemoryWriter = new Writer();
        }

        private void SharedMemoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sharedMemoryWriter.Dispose();
            _sharedMemoryWriter = null;
        }

        private void UpdateSample()
        {
            BMS4FlightData flightData = new BMS4FlightData();
            flightData.bearing = new float[FlightData.MAX_RWR_OBJECTS];
            flightData.DEDLines = new DED_PFL_LineOfText[5];
            flightData.Invert = new DED_PFL_LineOfText[5];
            flightData.lethality = new float[FlightData.MAX_RWR_OBJECTS];
            flightData.missileActivity = new uint[FlightData.MAX_RWR_OBJECTS];
            flightData.missileLaunch = new uint[FlightData.MAX_RWR_OBJECTS];
            flightData.newDetection = new uint[FlightData.MAX_RWR_OBJECTS];
            flightData.PFLInvert = new DED_PFL_LineOfText[5];
            flightData.PFLLines = new DED_PFL_LineOfText[5];
            flightData.RWRsymbol = new int[FlightData.MAX_RWR_OBJECTS];
            flightData.selected = new uint[FlightData.MAX_RWR_OBJECTS];
            
            flightData.lightBits = GetLightBits();

            int size = Marshal.SizeOf(flightData);
            _sample.PrimaryFlightData = new byte[size];
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(flightData, ptr, true);
                Marshal.Copy(ptr, _sample.PrimaryFlightData, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            WriteSampleToSharedMemory();
        }

        private uint GetLightBits()
        {
            LightBits lightBits = new LightBits();
            lightBits = 0;

            if (cbMasterCaution.Checked)
                lightBits |= LightBits.MasterCaution;

            if (cbTF.Checked)
                lightBits |= LightBits.TF;

            if (cbOXY_BROW.Checked)
                lightBits |= LightBits.OXY_BROW;

            if (cbEQUIP_HOT.Checked)
                lightBits |= LightBits.EQUIP_HOT;

            if (cbONGROUND.Checked)
                lightBits |= LightBits.ONGROUND;

            if (cbENG_FIRE.Checked)
                lightBits |= LightBits.ENG_FIRE;

            return ((uint)lightBits);
        }

        private void WriteSampleToSharedMemory()
        {
            if (_sample.PrimaryFlightData != null)
            {
                try
                {
                    _sharedMemoryWriter.WritePrimaryFlightData(_sample.PrimaryFlightData);
                }
                catch { }
            }
            if (_sample.FlightData2 != null)
            {
                try
                {
                    _sharedMemoryWriter.WriteFlightData2(_sample.FlightData2);
                }
                catch { }
            }
            if (_sample.OSBData != null)
            {
                try
                {
                    _sharedMemoryWriter.WriteOSBData(_sample.OSBData);
                }
                catch { }
            }
            if (_sample.IntellivibeData != null)
            {
                try
                {
                    _sharedMemoryWriter.WriteIntellivibeData(_sample.IntellivibeData);
                }
                catch { }
            }
            if (_sample.RadioClientStatusData != null)
            {
                try
                {
                    _sharedMemoryWriter.WriteRadioClientStatusData(_sample.RadioClientStatusData);
                }
                catch { }
            }
            if (_sample.RadioClientControlData != null)
            {
                try
                {
                    _sharedMemoryWriter.WriteRadioClientControlData(_sample.RadioClientControlData);
                }
                catch { }
            }
            if (_sample.StringData != null)
            {
                try
                {
                    _sharedMemoryWriter.WriteDrawingData(_sample.StringData);
                }
                catch { }
            }
            if (_sample.DrawingData != null)
            {
                try
                {
                    _sharedMemoryWriter.WriteDrawingData(_sample.DrawingData);
                }
                catch { }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateSample();
        }
    }
}
