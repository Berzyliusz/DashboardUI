using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace CarSystems.View
{
    public class MusicHandler
    {
        readonly Slider playbackSlider;
        readonly TextMeshProUGUI playbackTimer;
        readonly MusicReferences songs;

        readonly Vector3 centerPosition;
        readonly Vector3 firstRightPosition;
        readonly Vector3 firstLeftPosition;
        readonly Vector3 secondRightPosition;
        readonly Vector3 secondLeftPosition;

        readonly Vector3 firstRightRotation = new Vector3(0, 40, 0);
        readonly Vector3 firstLeftRotation = new Vector3(0, -40, 0);
        readonly Vector3 secondRightRotation = new Vector3(0, 50, 0);
        readonly Vector3 secondLeftRotation = new Vector3(0, -50, 0);

        readonly float tweenDuration = 0.5f;
        readonly float firstNeighbourOffset = 120f;
        readonly float secondNeighbourOffset = 170f;
        readonly float firstNeighbourScale = 0.8f;
        readonly float secondNeighbourScale = 0.6f;

        HashSet<int> usedIndexes = new HashSet<int>();

        int currentSong;
        float timeOfSongStart;
        float mockEverySongLength = 20f;

        public MusicHandler(MusicPlayerReferences references, MusicReferences songs)
        {
            playbackSlider = references.PlaybackSlider;
            playbackTimer = references.PlaybackTimer;
            centerPosition = references.CentralPosition.transform.position;
            firstRightPosition = new Vector3(centerPosition.x + firstNeighbourOffset, centerPosition.y, centerPosition.z);
            firstLeftPosition = new Vector3(centerPosition.x - firstNeighbourOffset, centerPosition.y, centerPosition.z);
            secondRightPosition = new Vector3(centerPosition.x + secondNeighbourOffset, centerPosition.y, centerPosition.z);
            secondLeftPosition = new Vector3(centerPosition.x - secondNeighbourOffset, centerPosition.y, centerPosition.z);

            this.songs = songs; // Assume we would also get songs data, album covers etc. injected here, maybe after construction.

            SwapSongs();
        }

        public void Next()
        {
            currentSong++;
            if(currentSong >= songs.musicReferences.Length)
                currentSong= 0;

            ResetTimerAndSlider();
            SwapSongs();
        }

        public void Previous()
        {
            currentSong--;
            if(currentSong < 0)
                currentSong = songs.musicReferences.Length - 1;

            ResetTimerAndSlider();
            SwapSongs();
        }

        public void Update(float deltaTime)
        {
            var playedSeconds = Time.realtimeSinceStartup - timeOfSongStart;
            var timeSpan = TimeSpan.FromSeconds(playedSeconds);
            playbackTimer.text = timeSpan.ToString(@"m\:ss"); ;
            playbackSlider.value = playedSeconds / mockEverySongLength;
        }

        void ResetTimerAndSlider()
        {
            timeOfSongStart = Time.realtimeSinceStartup;
            playbackSlider.value = 0;
            playbackTimer.text = "0:00";
        }

        void SwapSongs()
        {
            usedIndexes.Clear();

            var currentlyPlayedSong = songs.musicReferences[currentSong].transform;
            usedIndexes.Add(currentSong);
            
            currentlyPlayedSong.DOMove(centerPosition, tweenDuration);
            currentlyPlayedSong.DOScale(1, tweenDuration);
            currentlyPlayedSong.DORotate(Vector3.zero, tweenDuration);

            SetRightNeighbours();
            SetLeftNeighbours();
            currentlyPlayedSong.SetAsLastSibling();

            HideUnusedElements();
        }

        void SetRightNeighbours()
        {
            int firstIndex;
            int secondIndex;

            if (currentSong + 1 < songs.musicReferences.Length)
            {
                firstIndex = currentSong + 1;
            }
            else
            {
                firstIndex = 0;
            }

            if (currentSong + 2 < songs.musicReferences.Length)
            {
                secondIndex = currentSong + 2;
            }
            else
            {
                if(firstIndex == 0)
                    secondIndex= 1;
                else
                    secondIndex = 0;
            }

            Transform firstRightNeighbour = songs.musicReferences[firstIndex].transform;

            firstRightNeighbour.SetSiblingIndex(songs.musicReferences.Length - 1);
            firstRightNeighbour.DOMove(firstRightPosition, tweenDuration);
            firstRightNeighbour.DOScale(firstNeighbourScale, tweenDuration);
            firstRightNeighbour.DORotate(firstRightRotation, tweenDuration);

            Transform secondRightNeighbour = songs.musicReferences[secondIndex].transform;

            secondRightNeighbour.SetSiblingIndex(songs.musicReferences.Length - 2);
            secondRightNeighbour.DOMove(secondRightPosition, tweenDuration);
            secondRightNeighbour.DOScale(secondNeighbourScale, tweenDuration);
            secondRightNeighbour.DORotate(secondRightRotation, tweenDuration);

            usedIndexes.Add(firstIndex);
            usedIndexes.Add(secondIndex);
        }

        void SetLeftNeighbours()
        {
            int firstIndex;
            int secondIndex;

            if (currentSong - 1 < 0)
            {
                firstIndex = songs.musicReferences.Length - 1;
                secondIndex = songs.musicReferences.Length - 2;
            }
            else
            {
                firstIndex = currentSong - 1;
            }

            if (currentSong - 2 < 0)
            {
                if (firstIndex == songs.musicReferences.Length - 1)
                    secondIndex = songs.musicReferences.Length - 2;
                else
                    secondIndex = songs.musicReferences.Length - 1;
            }
            else
            {
                secondIndex = currentSong - 2;
            }

            Transform firstLeftNeighbour = songs.musicReferences[firstIndex].transform;

            firstLeftNeighbour.SetSiblingIndex(songs.musicReferences.Length - 3);
            firstLeftNeighbour.DOMove(firstLeftPosition, tweenDuration);
            firstLeftNeighbour.DOScale(firstNeighbourScale, tweenDuration);
            firstLeftNeighbour.DORotate(firstLeftRotation, tweenDuration);

            Transform secondLeftNeighbour = songs.musicReferences[secondIndex].transform;

            secondLeftNeighbour.SetSiblingIndex(songs.musicReferences.Length - 5);
            secondLeftNeighbour.DOMove(secondLeftPosition, tweenDuration);
            secondLeftNeighbour.DOScale(secondNeighbourScale, tweenDuration);
            secondLeftNeighbour.DORotate(secondLeftRotation, tweenDuration);

            usedIndexes.Add(firstIndex);
            usedIndexes.Add(secondIndex);
        }


        void HideUnusedElements()
        {
            for(int i = 0; i < songs.musicReferences.Length; i++)
            {
                if(!usedIndexes.Contains(i))
                {
                    Transform unusedElement = songs.musicReferences[i].transform;
                    unusedElement.localScale = Vector3.zero;
                    unusedElement.position = centerPosition;
                }
            }
        }
    }
}