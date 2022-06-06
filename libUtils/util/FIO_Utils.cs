﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
	public static class FIO
	{
		public static List<string> traverseSearchFile_Ext(string root, string ext)
		{
			List<string> ret_val = new List<string>();
			// Data structure to hold names of subfolders to be
			// examined for files.
			Stack<string> dirs = new Stack<string>();

			if (!System.IO.Directory.Exists(root))
			{
				throw new ArgumentException();
			}
			dirs.Push(root);

			while (dirs.Count > 0)
			{
				string currentDir = dirs.Pop();
				string[] subDirs;
				try
				{
					subDirs = System.IO.Directory.GetDirectories(currentDir);
				}
				// An UnauthorizedAccessException exception will be thrown if we do not have
				// discovery permission on a folder or file. It may or may not be acceptable
				// to ignore the exception and continue enumerating the remaining files and
				// folders. It is also possible (but unlikely) that a DirectoryNotFound exception
				// will be raised. This will happen if currentDir has been deleted by
				// another application or thread after our call to Directory.Exists. The
				// choice of which exceptions to catch depends entirely on the specific task
				// you are intending to perform and also on how much you know with certainty
				// about the systems on which this code will run.
				catch (UnauthorizedAccessException e)
				{
					Console.WriteLine(e.Message);
					continue;
				}
				catch (System.IO.DirectoryNotFoundException e)
				{
					Console.WriteLine(e.Message);
					continue;
				}

				string[] files = null;
				try
				{
					files = System.IO.Directory.GetFiles(currentDir);
				}

				catch (UnauthorizedAccessException e)
				{

					Console.WriteLine(e.Message);
					continue;
				}

				catch (System.IO.DirectoryNotFoundException e)
				{
					Console.WriteLine(e.Message);
					continue;
				}
				// Perform the required action on each file here.
				// Modify this block to perform your required task.
				foreach (string f in files)
				{
					try
					{
						// Perform whatever action is required in your scenario.
						System.IO.FileInfo fi = new System.IO.FileInfo(f);
						Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
						if (Path.GetExtension(f).Equals(ext))
							ret_val.Add(f);
					}
					catch (System.IO.FileNotFoundException e)
					{
						// If file was deleted by a separate application
						//  or thread since the call to TraverseTree()
						// then just continue.
						Console.WriteLine(e.Message);
						continue;
					}
				}

				// Push the subdirectories onto the stack for traversal.
				// This could also be done before handing the files.
				foreach (string str in subDirs)
					dirs.Push(str);
			}

			return ret_val;
		}

		public static void mergeTextFiles(string[] files, string ofname, bool append)
		{
			StreamWriter sw = new StreamWriter(ofname, append);
			foreach (string f in files)
			{
				string[] lines = File.ReadAllLines(f);

				foreach (string line in lines)
					sw.WriteLine(line);

				sw.Flush();
			}
			sw.Close();
		}
	}
}
