using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.WindowsAPICodePack.Dialogs;
using ReactiveUI;

namespace MediaCatalogue.Components
{
    // TODO: This needs to be reworked as a func/delegate sender. The ReactiveCommand must be created in VM so we can
    // subscribe to it and reflect the changes to parent over there.
    public static class MediaMenuCommand
    {
        private static readonly Dictionary<string, ICommand> Commands;

        static MediaMenuCommand()
        {
            Commands = new Dictionary<string, ICommand>()
            {
                {"_New", NewFileCommand()}
            };
        }
        
        /// <summary>
        /// Retrieves the command corresponding to the provided <paramref name="commandKey"/> provided.
        /// </summary>
        /// <param name="commandKey">Header of the Media Menu Item.</param>
        /// <returns>Command for the Media Menu Item queried.</returns>
        public static ICommand GetMenuCommand(string commandKey)
        {
            Commands.TryGetValue(commandKey, out var command);
            return command;
        }

        private static ICommand NewFileCommand()
        {
            return ReactiveCommand.Create(
                execute: () =>
                {
                    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    var saveDialog = new CommonSaveFileDialog()
                    {
                        Title = "Create Media Database File",
                        ShowHiddenItems = false,
                        AddToMostRecentlyUsedList = false,
                        ShowPlacesList = true,
                        CreatePrompt = false,
                        DefaultExtension = ".db",
                        DefaultFileName = "MediaCatalogue",
                        DefaultDirectory = documentsPath,
                        Filters = { new CommonFileDialogFilter("SQLite Database","*.db")}
                    };
                    try
                    {
                        if (saveDialog.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            Console.WriteLine(saveDialog.FileName);
                            return saveDialog.FileName;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                    return null;
                });
        }

        private static IReactiveCommand? OpenFileCommand()
        {
            // TODO: Implement OpenFileDialog picker here.
            return default;
        }
    }
}