Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraScheduler
Imports System.IO

Namespace ReportInCode
	Friend Class DataHelper
		Public Const aptDataResourceName As String = "ReportInCode.Data.appointments.xml"
		Public Const resDataResourceName As String = "ReportInCode.Data.resources.xml"

		Public Shared Sub FillStorageData(ByVal storage As SchedulerStorage)
			FillStorageCollection(storage.Resources.Items, resDataResourceName)
			FillStorageCollection(storage.Appointments.Items, aptDataResourceName)
		End Sub

		Private Shared Sub FillStorageCollection(ByVal c As AppointmentCollection, ByVal resourceName As String)
			Using stream As Stream = GetResourceStream(resourceName)
				c.ReadXml(stream)
				stream.Close()
			End Using
		End Sub
		Private Shared Sub FillStorageCollection(ByVal c As ResourceCollection, ByVal resourceName As String)
			Using stream As Stream = GetResourceStream(resourceName)
				c.ReadXml(stream)
				stream.Close()
			End Using
		End Sub

		Private Shared Function GetResourceStream(ByVal resourceName As String) As Stream
			Return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)
		End Function
	End Class
End Namespace
