using UnityEngine;
using UnityEngine.EventSystems;

public class PictureSwaper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("References")]
    [SerializeField] private Animator pictureAnimator;
    [SerializeField] private float marginToDiscard = 0.8f;

    private float inputDownXStart;

    private int swipeRightAnimID = Animator.StringToHash("SwipeRight");
    private int SwipeRight_PlaybackModeAnimID = Animator.StringToHash("SwipeRight_PlaybackMode");
    private int DiscardAnimID = Animator.StringToHash("Discard");
    private int playbackTimeParameterID = Animator.StringToHash("PlaybackTime");
    private int SpeedMultiplierParameterID = Animator.StringToHash("SpeedMultiplier");

    public void OnPointerDown(PointerEventData eventData)
    {
        inputDownXStart = eventData.position.x;
        pictureAnimator.Play(SwipeRight_PlaybackModeAnimID);
        pictureAnimator.SetFloat(playbackTimeParameterID, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (pictureAnimator.GetFloat(playbackTimeParameterID) < marginToDiscard)
        {
            pictureAnimator.SetFloat(SpeedMultiplierParameterID, -1f);
            pictureAnimator.Play(swipeRightAnimID, 0, pictureAnimator.GetFloat(playbackTimeParameterID));
        }
        else
            pictureAnimator.Play(DiscardAnimID);
    }

    public void OnDrag(PointerEventData eventData)
    {
        float delta = eventData.position.x - inputDownXStart;
        if (delta > 0)
        {
            delta = Mathf.Clamp(delta, 0, 500);
            pictureAnimator.SetFloat(playbackTimeParameterID, delta / 500f);
        }
    }
}
