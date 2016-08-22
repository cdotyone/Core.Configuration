node('windows') {
    git branch: 'master', credentialsId: '9678bd1f-e6af-4514-9193-50cb41afc960', url: 'git@git.civic360.com:Civic.Core/Configuration.git'

    def workspace = pwd()
    bat('C:\\Builds\\.nuget\\nuget.exe  restore Civic.Core.Configuration.sln -ConfigFile C:\\Build\\.nuget\\NuGet.Config')
    bat('"C:\\Program Files (x86)\\MSBuild\\14.0\\Bin\\amd64\\msbuild.exe" Civic.Core.Configuration.sln /tv:14.0 /p:DoEvents=false /p:Configuration="Nuget" /p:Platform="Any Cpu"')

    bat("C:\\Builds\\.nuget\\AssemblyVersionSetter.exe -e ${env.BUILD_NUMBER}.0 \"${workspace}\\References\"")
    bat("C:\\Builds\\.nuget\\pack.bat \"${workspace}\" \"${workspace}\"")
}
