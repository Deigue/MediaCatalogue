using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using MediaCatalogue.ViewModels;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using ReactiveUI;

namespace MediaCatalogue.Components
{
    // TODO: This needs to be reworked as a func/delegate sender. The ReactiveCommand must be created in VM so we can
    // subscribe to it and reflect the changes to parent over there.
    public static class MediaMenuCommand
    {
        private static readonly Dictionary<string, ReactiveCommand<MenuViewModel?, Unit>> Commands;

        static MediaMenuCommand()
        {
            Commands = new Dictionary<string, ReactiveCommand<MenuViewModel?, Unit>>()
            {
                {"_New", NewFileCommand()}
            };
        }

        /// <summary>
        /// Retrieves the command corresponding to the provided <paramref name="commandKey"/> provided.
        /// </summary>
        /// <param name="viewModel">Source MenuViewModel from which Command is being obtained from.</param>
        /// <param name="commandKey">Header of the Media Menu Item.</param>
        /// <returns>Command for the Media Menu Item queried.</returns>
        public static ReactiveCommand<MenuViewModel?, Unit> GetMenuCommand<TViewModel>(
            this TViewModel viewModel,
            string commandKey)
            where TViewModel : MenuViewModel
        {
            Commands.TryGetValue(commandKey, out var command);
            return command;
        }

        private static ReactiveCommand<MenuViewModel?, Unit> NewFileCommand()
        {
            return ReactiveCommand.Create<MenuViewModel?>(
                execute: (vm) =>
                {
                    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    var saveDialog = new CommonSaveFileDialog()
                    {
                        Title = "Create Media Database File",
                        ShowHiddenItems = false,
                        AddToMostRecentlyUsedList = false,
                        ShowPlacesList = true,
                        CreatePrompt = false,
                        //DefaultExtension = ".db",
                        //AlwaysAppendDefaultExtension = false,
                        DefaultFileName = "MediaCatalogue.db",
                        DefaultDirectory = documentsPath,
                        Filters = {new CommonFileDialogFilter("SQLite Database", "*.db,*.sqlite")}
                    };

                    try
                    {
                        if (saveDialog.ShowDialog() != CommonFileDialogResult.Ok) return;
                        // todo: replace with SeriLog.
                        //Console.WriteLine(saveDialog.FileName);
                        if (vm == null) return;
                        if (saveDialog.Filters.Any(filter =>
                            filter.Extensions.Contains(Path.GetExtension(saveDialog.FileName).TrimStart('.'))))
                        {
                            vm.MediaVm.Path = saveDialog.FileName;
                        }
                    }
                    catch (Exception e)
                    {
                        // TODO: replace with SeriLog.
                        Console.WriteLine(e);
                        throw;
                    }

                    //return null;
                });
        }

        private static IReactiveCommand? OpenFileCommand()
        {
            // TODO: Implement OpenFileDialog picker here.
            return default;
        }
    }
}