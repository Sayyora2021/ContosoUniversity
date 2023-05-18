Dim FSO, WshShell, objWMIService

Set FSO = CreateObject("Scripting.FileSystemObject")
Set WshShell = WScript.CreateObject("WScript.Shell")
Set objWMIService = GetObject("winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")

If MsgBox("Clean Up :" & WshShell.CurrentDirectory, vbYesNo, "Demande") = vbYes Then
	DeleteSubFolders(WshShell.CurrentDirectory)		 
End If

Sub DeleteSubFolders(strFolderName)
    Set colfolders = objWMIService.ExecQuery("Associators of {Win32_Directory.Name='" & strFolderName & "'} " & "Where AssocClass = Win32_Subdirectory " & "ResultRole = PartComponent")
    
    For Each objFolder in colFolders
                        
        strSubFolderPath = objFolder.Name   
             
        DeleteSubFolders(strSubFolderPath)          
        
        strSubFolderName = GetSubFolderName(strSubFolderPath)
        If strSubFolderName = "bin" Or strSubFolderName = "obj" Or strSubFolderName = ".vs" Or strFolderName = "BenchmarkDotNet.Artifacts" Then            
	        FSO.DeleteFolder strSubFolderPath, True	        
        End If
	
    Next
    
End Sub

Function GetSubFolderName(strFolderPath)
	i = InStrRev(strFolderPath,"\")
	If i > 0 Then
		GetSubFolderName = MID(strFolderPath, i+1)
	Else
		GetSubFolderName = ""	
	End If
End Function