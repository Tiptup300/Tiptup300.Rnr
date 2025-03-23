using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Tiptup300;

namespace Tiptup300.Rnr.PowerShellScriptModule;

public class CustomPSHost : PSHost
{
   private PSHostUserInterface _ui;
   private string _hostName = "CustomHost";

   public CustomPSHost()
   {
      _ui = new CustomPSHostUserInterface();
   }

   public override string Name => _hostName;
   public override PSHostUserInterface UI => _ui;

   public override Version Version => new Version(1, 0);

   public override Guid InstanceId => Guid.NewGuid();

   public override CultureInfo CurrentCulture => throw new NotImplementedException();

   public override CultureInfo CurrentUICulture => throw new NotImplementedException();

   public override void SetShouldExit(int exitCode) { }
   public override void EnterNestedPrompt() { }
   public override void ExitNestedPrompt() { }
   public override void NotifyBeginApplication() { }
   public override void NotifyEndApplication() { }
}

public class CustomPSHostUserInterface : PSHostUserInterface
{
   public override PSHostRawUserInterface RawUI => null;

   public override void Write(string value)
   {
      Console.WriteLine("Custom Output: " + value);
   }

   public override void WriteLine(string value)
   {
      Console.WriteLine("Custom Output (Line): " + value);
   }

   // Other methods can be overridden as needed.
   public override void WriteErrorLine(string value) { Console.WriteLine("ERROR: " + value); }
   public override void WriteDebugLine(string value) { }
   public override void WriteVerboseLine(string value) { }
   public override void WriteWarningLine(string value) { }


   public override string ReadLine()
   {
      throw new NotImplementedException();
   }

   public override SecureString ReadLineAsSecureString()
   {
      throw new NotImplementedException();
   }

   public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
   {
      throw new NotImplementedException();
   }

   public override void WriteProgress(long sourceId, ProgressRecord record)
   {
      throw new NotImplementedException();
   }

   public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
   {
      throw new NotImplementedException();
   }

   public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
   {
      throw new NotImplementedException();
   }

   public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName, PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
   {
      throw new NotImplementedException();
   }

   public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
   {
      throw new NotImplementedException();
   }
}


public class PowershellModuleHost : IDisposable
{
   private PowerShell _powershell;
   private Runspace _runspace;

   public PowershellModuleHost()
   {
      //_powershell = PowerShell.Create();
      _powershell = PowerShell.Create(initialSessionState: InitialSessionState.CreateDefault());
      var customHost = new CustomPSHost();
      _runspace = RunspaceFactory.CreateRunspace(customHost);
      _runspace.Open();
      _powershell.Runspace = _runspace;
   }

   public PowerShellScriptModule Build()
   {
      var services = new ServiceCollection()
         .AddSingleton(_powershell)
         .AddSingleton<PowerShellScriptRunner>()
         .AddSingleton<PowerShellScriptModule>()
         .AddSingleton<PowerShellRnrScriptLoader>()
         .AddSingleton<PowerShellScriptMetadataScanner>()
         .AddSingleton<IFile, FileWrapper>();

      var serviceProvider = services.BuildServiceProvider();
      var scriptModule = serviceProvider.GetRequiredService<PowerShellScriptModule>();
      return scriptModule;
   }

   public void Dispose()
   {
      _runspace.Dispose();
      _powershell.Dispose();
   }
}
