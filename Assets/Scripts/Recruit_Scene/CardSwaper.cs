using UnityEngine;
using UnityEngine.EventSystems;

public class CardSwaper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("References")]
    [SerializeField] private Animator pictureAnimator;
    [SerializeField] private float marginToDiscard = 0.8f;

    private float inputDownXStart;

    private int anim_swipeRight = Animator.StringToHash("SwipeRight");
    private int anim_swipeRightPBMode = Animator.StringToHash("SwipeRight_PlaybackMode");
    private int anim_discardRight = Animator.StringToHash("DiscardRight");
    private int anim_swipeLeft = Animator.StringToHash("SwipeLeft");
    private int anim_swipeLeftPBMode = Animator.StringToHash("SwipeLeft_PlaybackMode");
    private int anim_discardLeft = Animator.StringToHash("DiscardLeft");
    private int parameter_playbackTime = Animator.StringToHash("PlaybackTime");
    private int parameter_speedMultiplier = Animator.StringToHash("SpeedMultiplier");

    public void OnPointerDown(PointerEventData eventData)
    {
        inputDownXStart = eventData.position.x;
        pictureAnimator.SetFloat(parameter_playbackTime, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(eventData.position.x < inputDownXStart)
        {
            //between center and far left
            if (pictureAnimator.GetFloat(parameter_playbackTime) > 0
            && pictureAnimator.GetFloat(parameter_playbackTime) < marginToDiscard)
            {
                pictureAnimator.SetFloat(parameter_speedMultiplier, -1f);
                pictureAnimator.Play(anim_swipeLeft, 0, pictureAnimator.GetFloat(parameter_playbackTime));
            }
            //far left
            else
            {
                pictureAnimator.Play(anim_discardLeft);
                EventManager.Trigger("PirateDiscarded");
            }
        }
        else
        {
            //between center and far right
            if (pictureAnimator.GetFloat(parameter_playbackTime) > 0 
                && pictureAnimator.GetFloat(parameter_playbackTime) < marginToDiscard)
            {
                pictureAnimator.SetFloat(parameter_speedMultiplier, -1f);
                pictureAnimator.Play(anim_swipeRight, 0, pictureAnimator.GetFloat(parameter_playbackTime));
            }
            //far right
            else
            {
                pictureAnimator.Play(anim_discardRight);
                //EventManager.Trigger("PirateChoosen");
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        float delta = eventData.position.x - inputDownXStart;
        if (delta > 0)
        {
            pictureAnimator.Play(anim_swipeRightPBMode);
        }
        else if (delta < 0)
        {
            pictureAnimator.Play(anim_swipeLeftPBMode);
        }
        delta = Mathf.Abs(Mathf.Clamp(delta, -500, 500));
        pictureAnimator.SetFloat(parameter_playbackTime, delta / 500f);
    }
}
