using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VRQualityTesting.Scripts.Core;
using VRQualityTesting.Scripts.MainMenu;
using VRQualityTesting.Scripts.Utility;
using VRQualityTesting.Scripts.BoxSmasherMenu;

namespace VRQualityTesting.Scripts.BoxSmasher
{
    public class Session : ISession
    {
        private const string BoxResultsHeader = "Was smashed, Hand side, Box size";

        public string StudyID => Settings.GetString(MainMenuKeys.StudyID);
        public string ParticipantID => Settings.GetString(MainMenuKeys.ParticipantID);
        public GameTitle GameTitle => GameTitle.BoxSmasher;

        private readonly List<BoxResult> _boxResults;

        public Session(List<BoxResult> boxResults)
        {
            _boxResults = boxResults;
        }

        public List<string> GeneralInformation
        {
            get
            {
                var totalBoxes = _boxResults.Count;
                var hits = _boxResults.Count(box => box.WasSmashed);
                var hitsByRightHand = _boxResults.Count(box => box.HandSide == HandSide.Right);
                var hitsByLeftHand = hits - hitsByRightHand;

                return new List<string>
                {
                    "# Round results",
                    $"Total boxes: {totalBoxes}",
                    $"Hits: {hits}",
                    $"Hits by right hand: {hitsByRightHand}",
                    $"Hits by left hand: {hitsByLeftHand}",
                    $"Misses: {totalBoxes - hits}",
                    $"Accuracy: {((float) hits / totalBoxes).ToString(CultureInfo.InvariantCulture)}",
                    $"Duration: {Settings.GetFloat(BoxSmasherKeys.RoundDuration).ToString(CultureInfo.InvariantCulture)}",

                    $"{Environment.NewLine}# Cannon spawner settings",
                    $"Spawn distance: {Settings.GetFloat(BoxSmasherKeys.SpawnDistance).ToString(CultureInfo.InvariantCulture)}",
                    $"Spawn height: {Settings.GetFloat(BoxSmasherKeys.SpawnHeight).ToString(CultureInfo.InvariantCulture)}",
                    $"Spawn angle: {Settings.GetFloat(BoxSmasherKeys.SpawnAngle).ToString(CultureInfo.InvariantCulture)}",
                    $"Spawn count: {Settings.GetInt(BoxSmasherKeys.SpawnCount).ToString(CultureInfo.InvariantCulture)}",
                    $"Tilt angle: {Settings.GetFloat(BoxSmasherKeys.TiltAngle).ToString(CultureInfo.InvariantCulture)}",

                    $"{Environment.NewLine}# Cannon settings",
                    $"Min shoot force: {Settings.GetFloat(BoxSmasherKeys.MinShootForce).ToString(CultureInfo.InvariantCulture)}",
                    $"Max shoot force: {Settings.GetFloat(BoxSmasherKeys.MaxShootForce).ToString(CultureInfo.InvariantCulture)}",
                    $"Min duration between shots: {Settings.GetFloat(BoxSmasherKeys.MinDurationBetweenShots).ToString(CultureInfo.InvariantCulture)}",
                    $"Max duration between shots: {Settings.GetFloat(BoxSmasherKeys.MaxDurationBetweenShots).ToString(CultureInfo.InvariantCulture)}",
                    $"Min box size: {Settings.GetFloat(BoxSmasherKeys.MinBoxSize).ToString(CultureInfo.InvariantCulture)}",
                    $"Max box size: {Settings.GetFloat(BoxSmasherKeys.MaxBoxSize).ToString(CultureInfo.InvariantCulture)}",

                    $"{Environment.NewLine}# Weapon settings",
                    $"Left hand type: {(WeaponType) Settings.GetInt(BoxSmasherKeys.LeftHandWeaponType)}",
                    $"Right hand type: {(WeaponType) Settings.GetInt(BoxSmasherKeys.RightHandWeaponType)}",
                    $"Left hand length: {Settings.GetFloat(BoxSmasherKeys.LeftHandWeaponLength).ToString(CultureInfo.InvariantCulture)}",
                    $"Right hand length: {Settings.GetFloat(BoxSmasherKeys.RightHandWeaponLength).ToString(CultureInfo.InvariantCulture)}",
                };
            }
        }

        public List<string> DetailedInformation
        {
            get
            {
                var detailedInformation = new List<string> {BoxResultsHeader};
                detailedInformation.AddRange(_boxResults.Select(box => $"{box.WasSmashed}, " +
                                                                       $"{(box.HandSide.HasValue ? box.HandSide.Value.ToString() : "-")}, " +
                                                                       $"{box.Size.ToString(CultureInfo.InvariantCulture)}"));
                return detailedInformation;
            }
        }
    }
}