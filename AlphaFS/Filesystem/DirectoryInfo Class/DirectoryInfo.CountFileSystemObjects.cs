/*  Copyright (C) 2008-2015 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy 
 *  of this software and associated documentation files (the "Software"), to deal 
 *  in the Software without restriction, including without limitation the rights 
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 *  copies of the Software, and to permit persons to whom the Software is 
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in 
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 *  THE SOFTWARE. 
 */

using System.Linq;
using System.Security;

namespace Alphaleonis.Win32.Filesystem
{
   partial class DirectoryInfo
   {
      #region AlphaFS

      /// <summary>[AlphaFS] Counts file system objects: files, folders or both) in a given directory.</summary>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      /// <returns>The counted number of file system objects.</returns>
      /// <exception cref="System.UnauthorizedAccessException">An exception is thrown case of access errors.</exception>
      [SecurityCritical]
      public long CountFileSystemObjects(DirectoryEnumerationOptions options)
      {
         return Directory.EnumerateFileSystemEntryInfosInternal<string>(Transaction, LongFullName, Path.WildcardStarMatchAll, options, PathFormat.LongFullPath).Count();
      }

      /// <summary>[AlphaFS] Counts file system objects: files, folders or both) in a given directory.</summary>
      /// <param name="searchPattern">
      ///   <para>The search string to match against the names of directories in path. This parameter can contain a</para>
      ///   <para>combination of valid literal path and wildcard (<see cref="Path.WildcardStarMatchAll"/> and <see cref="Path.WildcardQuestion"/>)</para>
      ///   <para>characters, but does not support regular expressions.</para>
      /// </param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      /// <returns>The counted number of file system objects.</returns>
      /// <exception cref="System.UnauthorizedAccessException">An exception is thrown case of access errors.</exception>
      [SecurityCritical]
      public long CountFileSystemObjects(string searchPattern, DirectoryEnumerationOptions options)
      {
         return Directory.EnumerateFileSystemEntryInfosInternal<string>(Transaction, LongFullName, searchPattern, options, PathFormat.LongFullPath).Count();
      }

      #endregion // AlphaFS
   }
}