﻿namespace EFCorePowerTools.ViewModels
{
    using Contracts.EventArgs;
    using Contracts.ViewModels;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Messaging;
    using CommunityToolkit.Mvvm.Input;
    using Shared.Models;
    using System;
    using System.Windows.Input;

    public class AdvancedModelingOptionsViewModel : ObservableObject, IAdvancedModelingOptionsViewModel
    {
        public event EventHandler<CloseRequestedEventArgs> CloseRequested;

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public ModelingOptionsModel Model { get; }

        public AdvancedModelingOptionsViewModel()
        {
            OkCommand = new RelayCommand(Ok_Executed);
            CancelCommand = new RelayCommand(Cancel_Executed);

            Model = new ModelingOptionsModel();
        }

        private void Ok_Executed()
        {
            CloseRequested?.Invoke(this, new CloseRequestedEventArgs(true));
        }

        private void Cancel_Executed()
        {
            CloseRequested?.Invoke(this, new CloseRequestedEventArgs(false));
        }

        void IAdvancedModelingOptionsViewModel.ApplyPresets(ModelingOptionsModel presets)
        {
            Model.UseDbContextSplitting = presets.UseDbContextSplitting;
            Model.MapSpatialTypes = presets.MapSpatialTypes;
            Model.MapHierarchyId = presets.MapHierarchyId;
            Model.MapNodaTimeTypes = presets.MapNodaTimeTypes;
            Model.UseEf6Pluralizer = presets.UseEf6Pluralizer;
            Model.UseBoolPropertiesWithoutDefaultSql = presets.UseBoolPropertiesWithoutDefaultSql;
            Model.UseNoConstructor = presets.UseNoConstructor;
            Model.UseNoDefaultConstructor = presets.UseNoDefaultConstructor;
            Model.UseNoNavigations = presets.UseNoNavigations;
            Model.UseNoObjectFilter = presets.UseNoObjectFilter;
            Model.UseNullableReferences = presets.UseNullableReferences;
            Model.UseSchemaFolders = presets.UseSchemaFolders;
            Model.UseManyToManyEntity = presets.UseManyToManyEntity;
        }
    }
}
