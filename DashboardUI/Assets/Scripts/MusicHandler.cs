using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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
        readonly Vector3 firstRightRotation = new Vector3(0, 50, 0);
        readonly Vector3 firstLeftRotation = new Vector3(0, -50, 0);

        float playbackTime;
        float mockEverySongLength = 59f;

        readonly float tweenDuration = 0.5f;
        readonly float firstNeighbourOffset = 120f;
        readonly float firstNeighbourScale = 0.7f;

        int currentSong;

        public MusicHandler(MusicPlayerReferences references, MusicReferences songs)
        {
            playbackSlider = references.PlaybackSlider;
            playbackTimer = references.PlaybackTimer;
            centerPosition = references.CentralPosition.transform.position;
            firstRightPosition = new Vector3(centerPosition.x + firstNeighbourOffset, centerPosition.y, centerPosition.z);
            firstLeftPosition = new Vector3(centerPosition.x - firstNeighbourOffset, centerPosition.y, centerPosition.z);

            this.songs = songs; // Assume we would also get songs data, album covers etc. injected here

            //Todo: Calculate positions according to offset of the reference central position

            SwapSongs();
        }

        public void Next()
        {
            currentSong++;
            if(currentSong >= songs.musicReferences.Length)
                currentSong= 0;

            ResetTimerAndSlider();
        }

        public void Previous()
        {
            currentSong--;
            if(currentSong < 0)
                currentSong = songs.musicReferences.Length - 1;

            ResetTimerAndSlider();
        }

        public void Update(float deltaTime)
        {
            playbackTime += deltaTime;
            //Todo: Swap to seconds counter

            if(playbackTime > mockEverySongLength)
            {
                ResetTimerAndSlider();
                return;
            }

            playbackTimer.text = playbackTime.ToString("0.00");
            playbackSlider.value = playbackTime / mockEverySongLength;
        }

        void ResetTimerAndSlider()
        {
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

            // shift others either into pre-assigned left 1,2 / right 1,2 positons
            // or move them out of scope 
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
    }
}