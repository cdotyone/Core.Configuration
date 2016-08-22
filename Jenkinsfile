node('windows') {
    def workspace = pwd()
    bat('C:\\Builds\\.nuget\\nuget.exe  restore Civic.Core.Configuration.sln -ConfigFile C:\\Build\\.nuget\\NuGet.Config')
    bat('"C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\amd64\\msbuild.exe" Civic.Core.Configuration.sln /tv:14.0 /p:DoEvents=false /p:Configuration="Nuget" /p:Platform="Any Cpu"')

    bat("C:\\Builds\\.nuget\\AssemblyVersionSetter.exe -e ${env.BUILD_NUMBER}.0 \"${workspace}\\References\"")
    bat("C:\\Builds\\.nuget\\pack.bat \"${workspace}\" \"${workspace}\"")
}
