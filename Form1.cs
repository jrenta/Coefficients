#region Header
/*  File: MacAdamsCoefficients
 *  Name: Julio C. Renta Jr.
 *  Date: April 2016
 *  Desc: Program with the following tasks:
 *        * Creates a digital version of the contour maps found in MacAdam's "Specification of Small Chromaticity Differences"
 *        * Input: x & y colorpoint
 *        * Extracts data from an excel file named "TBD"
 *        * Output: g11, g12 & g22 Coefficients
 * 
 *  Abbreviations:
 *  ICI: International Commission of Illumination
 *  CIE: Commision Internationale de I'Elcairage
 */
#endregion

#region Usages
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
#endregion




namespace MacAdamsCoefficients
{

    
    public partial class Form1 : Form
    {
        #region Global Variables
        //GLOBAL VARIABLES/////////////////////////////////////////////////
        String filename;
        Stream fileStream;
        StreamReader reader;
        int numDataPoints;
        int sheetsAvailable, gxxSheetsFound = 0;
        int g11_SheetIndex, g12_SheetIndex, g22_SheetIndex;
        double[] x, y;
        
        //STRUCT VARIABLES/////////////////////////////////////////////////
        public cieContourMaps cieMaps;
        public gxxMap g11, g12, g22;
        
        //EXCEL TYPE GLOBAL VARIABLES
        Excel.Application excel;
        Excel.Workbook wkb;
        Excel.Worksheet g11_Sheet, g12_Sheet, g22_Sheet;
        Excel.Range[] rng_xGamutOutlineValues, rng_yGamutOutlineValues;
        Excel.Range[] rng_xValues, rng_yValues;
        Excel.Range numOfCurves;
        //END OF GLOBAL VARIABLES///////////////////////////////////////////
        #endregion

        #region Structures
        //STRUCTURES////////////////////////////////////////////////////////
        curve[] aCurve;
        public struct curve
        {
            Excel.Range[] rng_Curve;
            public string curveName;
            public double[] x, y;
        }     

        public struct gxxMap
        {
            public int gxxSheetIndex;
            public string gxxMapName;
            public int numOfCurves;
            public curve[] curves;
            public Excel.Range[] rng_curveNames;
        }

        public struct cieContourMaps
        {
            public int numOfMaps;
        }
        //END OF STRUCTURES///////////////////////////////////////////////////
        #endregion

        #region Initialization
        //INITIALIZATION METHODS//////////////////////////////////////////////
        public Form1()
        {
            InitializeComponent();
        }

        public void initExcelData()
        {
            excel = new Excel.Application();
            excel.Application.Visible = true;

            wkb = excel.Workbooks.Open(filename);

            //Count how many sheets are available and put that number into variable: "int sheetsAvaliable"
            sheetsAvailable = wkb.Sheets.Count;

            //Scan for sheet names "g11, g12 & g22"
            //Store the index value of the sheet into g11_SheetIndex, g12_SheetIndex & g22_SheetIndex, respectively
            for (int i = 1; i < (sheetsAvailable + 1); i++)
            {
                Excel.Worksheet tempSheet = (Excel.Worksheet)wkb.Sheets[i];
                String sheetName = tempSheet.Name;
                switch (sheetName)
                {
                    case "g11":
                        g11_SheetIndex = i;
                        gxxSheetsFound++;
                        break;

                    case "g12":
                        g12_SheetIndex = i;
                        gxxSheetsFound++;
                        break;

                    case "g22":
                        g22_SheetIndex = i;
                        gxxSheetsFound++;
                        break;

                    default:
                        Console.WriteLine("Sheet at index " + i + " is named " + sheetName + " and was not used for extraction of data.");
                        break;
                }
            } 
        }

        public void initXYarray(int numOfDataPoints)
        {
            x = new double[numOfDataPoints];
            y = new double[numOfDataPoints];
        }

        //The number of curves in each gxx map will differ
        public void initCurveArray(int numOfCurves)
        {
            aCurve = new curve[numOfCurves];
        }

        //initMaps gets the number of maps found from Excel
        //Goes through each of the available gxx maps found and issues the Excel sheet index and name of contour map to the gxx struct
        public void initMaps()
        {   
            cieMaps.numOfMaps = gxxSheetsFound;
            //gxxContourMaps = new gxxMap[gxxSheetsFound];
            

            if (g11_SheetIndex != 0)
            {
                g11.gxxMapName = "g11";
                g11.gxxSheetIndex = g11_SheetIndex;
                g11_Sheet = wkb.Sheets[g11_SheetIndex];
                g11.numOfCurves = (int)g11_Sheet.Range["D1"].Value2;
            }
            if (g12_SheetIndex != 0)
            {
                g12.gxxMapName = "g12";
                g12.gxxSheetIndex = g12_SheetIndex;
            }
            if (g22_SheetIndex != 0)
            {
                g22.gxxMapName = "g22";
                g22.gxxSheetIndex = g22_SheetIndex;
            }
        }

        //END OF INITIALIZATION METHODS//////////////////////////////////////
        #endregion

        #region Get Methods
        //GET METHODS////////////////////////////////////////////////////////
        //Method: get_NumDataPoints gets the number of x&y data points for each curve into an array
        public void get_NumDataPoints(Excel.Range  rng_dataPoints)
        {
            numDataPoints = rng_dataPoints.Count;
        }

        //getCurveNameRange gets the range for all of the curve names for each gxx map
        public void getCurveNameRange(gxxMap gMap, Excel._Worksheet aSheet)
        {
            if (gMap.Equals(g11))
                gMap.rng_curveNames = aSheet.Range["D3", "CL3"].Value;
            else if (gMap.Equals(g12))
                gMap.rng_curveNames = aSheet.Range["D3", "CL3"].Value;
            else if (gMap.Equals(g22))
                gMap.rng_curveNames = aSheet.Range["D3", "CL3"].Value;
            else
                Console.WriteLine("The method: getCurveNameRange(gxxMap, Excel._Worksheet aSheet) could not identify a gMap.\n");
        }
      
        public void getCurveNames(gxxMap gMap, )
        { 
            int numCurves = 0; //This variable is different for every gmap (check if an abosolute value can be used)
            for(int i = 0; i < numCurves; i++)
            {
                g11.curves[i].curveName = g11_Sheet.Range[?].Value2; //If there was an array of ranges, it would be useful here
                g12.curves[i].curveName = g12_Sheet.Range[?].Value2; 
                g22.curves[i].curveName = g22_Sheet.Range[?].Value2;
            }
        }
    
        //END OF GET METHODS////////////////////////////////////////////////
        #endregion

        #region Set Methods
        //SET METHODS///////////////////////////////////////////////////////
        public void setXYarray(int numOfdataPoints, Excel.Range rngXvalues, Excel.Range rngYvalues)
        {
            for(int i = 0; i < numOfdataPoints + 1; i++)
            {
                x[i] = rngXvalues[i];
                y[i] = rngYvalues[i];
            }
        }        

        public void setCurveArray(int numOfCurves, Excel.Range rng_CurveName, int curveID)
        {
            aCurve[curveID].curveName = rng_CurveName.Cells.Value();
            for (int i = 0; i < numOfCurves + 1; i++)
            {
                
                aCurve[curveID].x[i] = x[i];
                aCurve[curveID].y[i] = y[i];
            }
        }
        //END OF SET METHODS///////////////////////////////////////////////////
        #endregion

        #region Buttons
        /*
         * This button performs the following actions:
         * Extracts data from specific cells found in an Excel file named in variable: "String fileName"
         * Extracted data gets converted into arrays so that they can be modified in the future
         * Data from array gets loaded to three overlapping graphs
         */
        public void btn_LoadGraph_Click(object sender, EventArgs e)
        {
            //initExcelData() opens the excel file, counts how many sheets were found & identifies the sheets named "g11", "g12" & "g22" as a sheet index
            initExcelData();
            //initMaps() initializes a number of maps equal to the number of gxx sheets found in excel
            //These maps associate names & sheetIndexes for every gxx map found in Excel.wkb(filename), respectively
            //It also gets the number of curves found on that gxx map
            initMaps();
            getCurveNameRange(g11, g11_Sheet);
            //getCurveNameRange(g12, g12_Sheet);
            //getCurveNameRange(g22, g22_Sheet);
            //getCurves() gets the names of the curves found in each gxx map and the range of the x,y points for each of those curves
            getCurveNames(g11);
         
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Excel Files *.xls|*.xlsx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            // Check if the user clicked OK.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Show the directory in txt_Browse
                filename = openFileDialog1.FileName;
                txt_Browse.Text = filename;

                // Open the selected file to read.
                fileStream = openFileDialog1.OpenFile();
            }
        }
        #endregion

        #region Form
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            fileStream.Close();
            // Close the workbook without saving changes.
            wkb.Close(false, Type.Missing, Type.Missing);
            // Close the Excel server.
            excel.Quit();
        }
        #endregion

    }

}
