using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ZipLibTest
{

    class Program
    {
        int entryCount;
        //@example: CSharpZipLib - Extract Zip File
        public static void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;		// AES encrypted entries are handled automatically
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;			// Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];		// 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
        }

        //@example: CSharpZipLib - Create Zip with Password and compression level
        public static void CreateSample(string outPathname, string password, string folderName)
        {

            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression

            //@example: SharpZipLib - zip set password
            zipStream.Password = password;	// optional. Null is the same as not setting.

            // This setting will strip the leading part of the folder path in the entries, to
            // make the entries relative to the starting folder.
            // To include the full path for each entry up to the drive root, assign folderOffset = 0.
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

            CompressFolder(folderName, zipStream, folderOffset);

            zipStream.IsStreamOwner = true;	// Makes the Close also Close the underlying stream
            zipStream.Close();
        }

        //@example: CSharpZipLib - compress folder to zip
        private static void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {

            string[] files = Directory.GetFiles(path);

            foreach (string filename in files)
            {

                FileInfo fi = new FileInfo(filename);

                string entryName = filename.Substring(folderOffset); // Makes the name in zip based on the folder
                entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = fi.LastWriteTime; // Note the zip format stores 2 second granularity

                // Specifying the AESKeySize triggers AES encryption. Allowable values are 0 (off), 128 or 256.
                //   newEntry.AESKeySize = 256;

                // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003, WinZip 8, Java, and other older code,
                // you need to do one of the following: Specify UseZip64.Off, or set the Size.
                // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, you do not need either,
                // but the zip will be in Zip64 format which not all utilities can understand.
                //   zipStream.UseZip64 = UseZip64.Off;
                newEntry.Size = fi.Length;

                zipStream.PutNextEntry(newEntry);

                // Zip the file in buffered chunks
                // the "using" will close the stream even if an exception occurs
                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }

        void EntryCounter(TarArchive archive, TarEntry entry, string message)
        {
            entryCount++;
        }

        static void Main(string[] args)
        {
            CreateSample(@"C:\dev\awork.zip", "hello", @"C:\dev\test");
            ExtractZipFile(@"C:\dev\awork.zip", "hello", @"c:\dev\1");

            //CZip.AddContextMenuItem(".txt", "open txt", "open txt file", "notepad %1");
        }
    }
}


/*
 * Unpack a Zip - including embedded zips - and re-pack into a new zip or memorystream¶
This sample illustrates two major aspects:

    how to extract files from embedded zips (a zip within a zip).
    how to rebuild the contents into a new zip (optionally changing compression levels and changing encryption).


This example includes disk vs memorystream.

C#
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

private ZipOutputStream _zipOut;
private byte[] _buffer = new byte[4096];

// This example illustrates reading an input disk file (or any input stream),
// extracting the individual files, including from embedded zipfiles,
// and writing them to a new zipfile with an output memorystream or disk file.
//
public void DoRebuildFile(string zipFileIn, string password) {

	Stream inStream = File.OpenRead(zipFileIn);

	MemoryStream outputMemStream = new MemoryStream();
	_zipOut = new ZipOutputStream(outputMemStream);
	_zipOut.IsStreamOwner = false;	// False stops the Close also Closing the underlying stream.

	// To output to a disk file, replace the above with
	//
	//   FileStream fsOut = File.Create(newZipFileName);
	//   _zipOut = new ZipOutputStream(fsOut);
	//   _zipOut.IsStreamOwner = true;	// Makes the Close also Close the underlying stream.

	_zipOut.SetLevel(3);
	_zipOut.Password = password;		// optional

	RecursiveExtractRebuild(inStream);
	inStream.Close();

	// Must finish the ZipOutputStream to finalise output before using outputMemStream.
	_zipOut.Close();

	outputMemStream.Position = 0;

	// At this point the underlying output memory stream (outputMemStream) contains the zip.
	// If outputting to a web response, see the "Create a Zip as a browser download attachment in IIS" example above.
	// See the "Create a Zip to a memory stream or byte array" example for other output options.
}

// Calls itself recursively if embedded zip
//
private void RecursiveExtractRebuild(Stream str) {

	ZipFile zipFile = new ZipFile(str);
	zipFile.IsStreamOwner = false;
	
	foreach (ZipEntry zipEntry in zipFile) {
		if (!zipEntry.IsFile)
			continue;
		String entryFileName = zipEntry.Name; // or Path.GetFileName(zipEntry.Name) to omit folder
		// Specify any other filtering here.

		Stream zipStream = zipFile.GetInputStream(zipEntry);
		// Zips-within-zips are extracted. If you don't want this and wish to keep embedded zips as-is, just delete these 3 lines. 
		if (entryFileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase)) {
			RecursiveExtractRebuild(zipStream);
		} else {
			ZipEntry newEntry = new ZipEntry(entryFileName);
			newEntry.DateTime = zipEntry.DateTime;
			newEntry.Size = zipEntry.Size;
			// Setting the Size will allow the zip to be unpacked by XP's built-in extractor and other older code.

			_zipOut.PutNextEntry(newEntry);

			StreamUtils.Copy(zipStream, _zipOut, _buffer);
			_zipOut.CloseEntry();
		}
	}
}
*/