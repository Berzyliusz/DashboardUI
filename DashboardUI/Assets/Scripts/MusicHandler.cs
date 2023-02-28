using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

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
            var currentlyPlayedSong = songs.musicReferences[currentSong].transform;

            currentlyPlayedSong.SetAsLastSibling();
            currentlyPlayedSong.DOMove(centerPosition, tweenDuration);
            currentlyPlayedSong.DOScale(1, tweenDuration);
            currentlyPlayedSong.DORotate(Vector3.zero, tweenDuration);

            SetFirstRightNeighbour();
            SetFirstLeftNeighbour();
            SetSecondRightNeighbour();
            SetSecondLeftNeighbour();

            
            // Hide others
        }

        void SetFirstRightNeighbour()
        {
            Transform rightNeighbour;
            if (currentSong + 1 < songs.musicReferences.Length - 2)
                rightNeighbour = songs.musicReferences[currentSong + 1].transform;
            else
                rightNeighbour = songs.musicReferences[0].transform;

            rightNeighbour.SetSiblingIndex(songs.musicReferences.Length - 2);
            rightNeighbour.DOMove(firstRightPosition, tweenDuration);
            rightNeighbour.DOScale(firstNeighbourScale, tweenDuration);
            rightNeighbour.DORotate(firstRightRotation, tweenDuration);
        }

        void SetFirstLeftNeighbour()
        {
            Transform leftNeighbour;
            if (currentSong - 1 < 0)
                leftNeighbour = songs.musicReferences[songs.musicReferences.Length - 1].transform;
            else
                leftNeighbour = songs.musicReferences[currentSong - 1].transform;

            leftNeighbour.SetSiblingIndex(songs.musicReferences.Length - 3);
            leftNeighbour.DOMove(firstLeftPosition, tweenDuration);
            leftNeighbour.DOScale(firstNeighbourScale, tweenDuration);
            leftNeighbour.DORotate(firstLeftRotation, tweenDuration);
        }

        void SetSecondRightNeighbour()
        {
            Transform rightNeighbour;
            if (currentSong + 2 < songs.musicReferences.Length - 2)
                rightNeighbour = songs.musicReferences[currentSong + 2].transform;
            else
                rightNeighbour = songs.musicReferences[1].transform;

            rightNeighbour.SetSiblingIndex(songs.musicReferences.Length - 4);
            rightNeighbour.DOMove(secondRightPosition, tweenDuration);
            rightNeighbour.DOScale(secondNeighbourScale, tweenDuration);
            rightNeighbour.DORotate(secondRightRotation, tweenDuration);
        }

        void SetSecondLeftNeighbour()
        {
            Transform leftNeighbour;
            if (currentSong - 2 < 0)
                leftNeighbour = songs.musicReferences[songs.musicReferences.Length - 2].transform;
            else
                leftNeighbour = songs.musicReferences[currentSong - 2].transform;

            leftNeighbour.SetSiblingIndex(songs.musicReferences.Length - 5);
            leftNeighbour.DOMove(secondLeftPosition, tweenDuration);
            leftNeighbour.DOScale(secondNeighbourScale, tweenDuration);
            leftNeighbour.DORotate(secondLeftRotation, tweenDuration);
        }
    }
}