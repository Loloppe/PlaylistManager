﻿using HarmonyLib;

namespace PlaylistManager.HarmonyPatches
{
    [HarmonyPatch(typeof(LevelCollectionViewController))]
    [HarmonyPatch("SetData", MethodType.Normal)]
    public class LevelCollectionViewController_SetData
    {
        internal static IPreviewBeatmapLevel[] beatmapLevels;
        internal static void Prefix(ref IBeatmapLevelCollection beatmapLevelCollection)
        {
            if (beatmapLevelCollection is BeatSaberPlaylistsLib.Legacy.LegacyPlaylist legacyPlaylist)
            {
                beatmapLevels = legacyPlaylist.BeatmapLevels;
            }
            else if (beatmapLevelCollection is BeatSaberPlaylistsLib.Blist.BlistPlaylist blistPlaylist)
            {
                beatmapLevels = blistPlaylist.BeatmapLevels;
            }
            else
            {
                beatmapLevels = beatmapLevelCollection.beatmapLevels;
            }
        }
    }
}