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
            // Primary FlightData
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
            flightData.lightBits2 = GetLightBits2();
            flightData.lightBits3 = GetLightBits3();
            flightData.hsiBits = GetHsiBits();

            {
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
            }

            // FlightData2
            FlightData2 flightData2 = new FlightData2();
            flightData2.ecmBits = new uint[FlightData2.MAX_ECM_PROGRAMS];
            flightData2.pilotsCallsign = new Callsign_LineOfText[FlightData2.MAX_CALLSIGNS];
            flightData2.pilotsStatus = new byte[FlightData2.MAX_CALLSIGNS];
            flightData2.RTT_area = new ushort[(int)RTT_areas.RTT_noOfAreas * 4];
            flightData2.RTT_size = new ushort[2];
            flightData2.RwrInfo = new byte[FlightData2.RWRINFO_SIZE];
            flightData2.RWRjammingStatus = new JammingStates[FlightData.MAX_RWR_OBJECTS];
            flightData2.tacanInfo = new byte[(int)TacanSources.NUMBER_OF_SOURCES];

            flightData2.blinkBits = GetBlinkBits();

            {
                int size = Marshal.SizeOf(flightData2);
                _sample.FlightData2 = new byte[size];
                IntPtr ptr = IntPtr.Zero;
                try
                {
                    ptr = Marshal.AllocHGlobal(size);
                    Marshal.StructureToPtr(flightData2, ptr, true);
                    Marshal.Copy(ptr, _sample.FlightData2, 0, size);
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr);
                }
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

            if (cbCONFIG.Checked)
                lightBits |= LightBits.CONFIG;

            if (cbHYD.Checked)
                lightBits |= LightBits.HYD;

            if (cbFlcs_ABCD.Checked)
                lightBits |= LightBits.Flcs_ABCD;

            if (cbFLCS.Checked)
                lightBits |= LightBits.FLCS;

            if (cbCAN.Checked)
                lightBits |= LightBits.CAN;

            if (cbT_L_CFG.Checked)
                lightBits |= LightBits.T_L_CFG;
            
            if (cbAOAAbove.Checked)
                lightBits |= LightBits.AOAAbove;

            if (cbAOAOn.Checked)
                lightBits |= LightBits.AOAOn;

            if (cbAOABelow.Checked)
                lightBits |= LightBits.AOABelow;
            
            if (cbRefuelRDY.Checked)
                lightBits |= LightBits.RefuelRDY;

            if (cbRefuelAR.Checked)
                lightBits |= LightBits.RefuelAR;

            if (cbRefuelDSC.Checked)
                lightBits |= LightBits.RefuelDSC;
            
            if (cbFltControlSys.Checked)
                lightBits |= LightBits.FltControlSys;

            if (cbLEFlaps.Checked)
                lightBits |= LightBits.LEFlaps;

            if (cbEngineFault.Checked)
                lightBits |= LightBits.EngineFault;
            
            if (cbOverheat.Checked)
                lightBits |= LightBits.Overheat;

            if (cbFuelLow.Checked)
                lightBits |= LightBits.FuelLow;

            if (cbAvionics.Checked)
                lightBits |= LightBits.Avionics;

            if (cbRadarAlt.Checked)
                lightBits |= LightBits.RadarAlt;

            if (cbIFF.Checked)
                lightBits |= LightBits.IFF;
            
            if (cbECM.Checked)
                lightBits |= LightBits.ECM;

            if (cbHook.Checked)
                lightBits |= LightBits.Hook;

            if (cbNWSFail.Checked)
                lightBits |= LightBits.NWSFail;

            if (cbCabinPress.Checked)
                lightBits |= LightBits.CabinPress;

            if (cbAutoPilotOn.Checked)
                lightBits |= LightBits.AutoPilotOn;

            if (cbTFR_STBY.Checked)
                lightBits |= LightBits.TFR_STBY;

            return ((uint)lightBits);
        }

        private uint GetLightBits2()
        {
            LightBits2 lightBits2 = new LightBits2();
            lightBits2 = 0;

            if (cbHandOff.Checked)
                lightBits2 |= LightBits2.HandOff;
            
            if (cbLaunch.Checked)
                lightBits2 |= LightBits2.Launch;

            if (cbPriMode.Checked)
                lightBits2 |= LightBits2.PriMode;

            if (cbNaval.Checked)
                lightBits2 |= LightBits2.Naval;

            if (cbUnk.Checked)
                lightBits2 |= LightBits2.Unk;

            if (cbTgtSep.Checked)
                lightBits2 |= LightBits2.TgtSep;
            
            if (cbGo.Checked)
                lightBits2 |= LightBits2.Go;

            if (cbNoGo.Checked)
                lightBits2 |= LightBits2.NoGo;

            if (cbDegr.Checked)
                lightBits2 |= LightBits2.Degr;

            if (cbRdy.Checked)
                lightBits2 |= LightBits2.Rdy;

            if (cbChaffLo.Checked)
                lightBits2 |= LightBits2.ChaffLo;

            if (cbFlareLo.Checked)
                lightBits2 |= LightBits2.FlareLo;
            
            if (cbAuxSrch.Checked)
                lightBits2 |= LightBits2.AuxSrch;

            if (cbAuxAct.Checked)
                lightBits2 |= LightBits2.AuxAct;

            if (cbAuxLow.Checked)
                lightBits2 |= LightBits2.AuxLow;

            if (cbAuxPwr.Checked)
                lightBits2 |= LightBits2.AuxPwr;
            
            if (cbEcmPwr.Checked)
                lightBits2 |= LightBits2.EcmPwr;

            if (cbEcmFail.Checked)
                lightBits2 |= LightBits2.EcmFail;
            
            if (cbFwdFuelLow.Checked)
                lightBits2 |= LightBits2.FwdFuelLow;

            if (cbAftFuelLow.Checked)
                lightBits2 |= LightBits2.AftFuelLow;
            
            if (cbEPUOn.Checked)
                lightBits2 |= LightBits2.EPUOn;

            if (cbJFSOn.Checked)
                lightBits2 |= LightBits2.JFSOn;
            
            if (cbSEC.Checked)
                lightBits2 |= LightBits2.SEC;

            if (cbOXY_LOW.Checked)
                lightBits2 |= LightBits2.OXY_LOW;

            if (cbPROBEHEAT.Checked)
                lightBits2 |= LightBits2.PROBEHEAT;

            if (cbSEAT_ARM.Checked)
                lightBits2 |= LightBits2.SEAT_ARM;

            if (cbBUC.Checked)
                lightBits2 |= LightBits2.BUC;

            if (cbFUEL_OIL_HOT.Checked)
                lightBits2 |= LightBits2.FUEL_OIL_HOT;

            if (cbANTI_SKID.Checked)
                lightBits2 |= LightBits2.ANTI_SKID;

            if (cbTFR_ENGAGED.Checked)
                lightBits2 |= LightBits2.TFR_ENGAGED;

            if (cbGEARHANDLE.Checked)
                lightBits2 |= LightBits2.GEARHANDLE;

            if (cbENGINE.Checked)
                lightBits2 |= LightBits2.ENGINE;

            return ((uint)lightBits2);
        }

        private uint GetLightBits3()
        {
            LightBits3 lightBits3 = new LightBits3();
            lightBits3 = 0;

            if (cbFlcsPmg.Checked)
                lightBits3 |= LightBits3.FlcsPmg;
            
            if (cbMainGen.Checked)
                lightBits3 |= LightBits3.MainGen;

            if (cbStbyGen.Checked)
                lightBits3 |= LightBits3.StbyGen;

            if (cbEpuGen.Checked)
                lightBits3 |= LightBits3.EpuGen;

            if (cbEpuPmg.Checked)
                lightBits3 |= LightBits3.EpuPmg;

            if (cbToFlcs.Checked)
                lightBits3 |= LightBits3.ToFlcs;

            if (cbFlcsRly.Checked)
                lightBits3 |= LightBits3.FlcsRly;

            if (cbBatFail.Checked)
                lightBits3 |= LightBits3.BatFail;
            
            if (cbHydrazine.Checked)
                lightBits3 |= LightBits3.Hydrazine;

            if (cbAir.Checked)
                lightBits3 |= LightBits3.Air;
            
            if (cbElec_Fault.Checked)
                lightBits3 |= LightBits3.Elec_Fault;

            if (cbLef_Fault.Checked)
                lightBits3 |= LightBits3.Lef_Fault;
            
            if (cbOnGround2.Checked)
                lightBits3 |= LightBits3.OnGround;
            
            if (cbFlcsBitRun.Checked)
                lightBits3 |= LightBits3.FlcsBitRun;

            if (cbFlcsBitFail.Checked)
                lightBits3 |= LightBits3.FlcsBitFail;

            if (cbDbuWarn.Checked)
                lightBits3 |= LightBits3.DbuWarn;

            if (cbNoseGearDown.Checked)
                lightBits3 |= LightBits3.NoseGearDown;

            if (cbLeftGearDown.Checked)
                lightBits3 |= LightBits3.LeftGearDown;

            if (cbRightGearDown.Checked)
                lightBits3 |= LightBits3.RightGearDown;

            if (cbParkBrakeOn.Checked)
                lightBits3 |= LightBits3.ParkBrakeOn;
            //
            if (cbPower_Off.Checked)
                lightBits3 |= LightBits3.Power_Off;

            if (cbcadc.Checked)
                lightBits3 |= LightBits3.cadc;

            if (cbSpeedBrake.Checked)
                lightBits3 |= LightBits3.SpeedBrake;

            if (cbSysTest.Checked)
                lightBits3 |= LightBits3.SysTest;

            if (cbMCAnnounced.Checked)
                lightBits3 |= LightBits3.MCAnnounced;

            if (cbMLGWOW.Checked)
                lightBits3 |= LightBits3.MLGWOW;

            if (cbNLGWOW.Checked)
                lightBits3 |= LightBits3.NLGWOW;

            if (cbATF_Not_Engaged.Checked)
                lightBits3 |= LightBits3.ATF_Not_Engaged;

            if (cbInlet_Icing.Checked)
                lightBits3 |= LightBits3.Inlet_Icing;

            return ((uint)lightBits3);
        }

        private uint GetHsiBits()
        {
            HsiBits hsiBits = new HsiBits();
            hsiBits = 0;

            if (cbIlsWarning.Checked)
                hsiBits |= HsiBits.IlsWarning;
            
            if (cbCourseWarning.Checked)
                hsiBits |= HsiBits.CourseWarning;

            if (cbInit.Checked)
                hsiBits |= HsiBits.Init;

            if (cbTotalFlags.Checked)
                hsiBits |= HsiBits.TotalFlags;

            if (cbADI_OFF.Checked)
                hsiBits |= HsiBits.ADI_OFF;

            if (cbADI_AUX.Checked)
                hsiBits |= HsiBits.ADI_AUX;

            if (cbADI_GS.Checked)
                hsiBits |= HsiBits.ADI_GS;

            if (cbADI_LOC.Checked)
                hsiBits |= HsiBits.ADI_LOC;

            if (cbHSI_OFF.Checked)
                hsiBits |= HsiBits.HSI_OFF;
            
            if (cbBUP_ADI_OFF.Checked)
                hsiBits |= HsiBits.BUP_ADI_OFF;

            if (cbVVI.Checked)
                hsiBits |= HsiBits.VVI;

            if (cbAOA.Checked)
                hsiBits |= HsiBits.AOA;

            if (cbAVTR.Checked)
                hsiBits |= HsiBits.AVTR;

            if (cbOuterMarker.Checked)
                hsiBits |= HsiBits.OuterMarker;

            if (cbMiddleMarker.Checked)
                hsiBits |= HsiBits.MiddleMarker;
            //
            if (cbFromTrue.Checked)
                hsiBits |= HsiBits.FromTrue;

            if (cbFlying.Checked)
                hsiBits |= HsiBits.Flying;

            return ((uint)hsiBits);
        }

        private uint GetBlinkBits()
        {
            BlinkBits blinkBits = new BlinkBits();
            blinkBits = 0;

            if (cbBBOuterMarker.Checked)
                blinkBits |= BlinkBits.OuterMarker;

            return (uint)blinkBits;
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

        // Update BlinkBit Checkmarks
        private void cbOuterMarker_CheckedChanged(object sender, EventArgs e)
        {
            cbLBOuterMarker.Checked = cbOuterMarker.Checked;
        }
    }
}
