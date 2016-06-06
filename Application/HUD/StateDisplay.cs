using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Application.HUD
{
    
    public enum State_Info_Type {INFO, WARNING, ERROR}

    public class StateDisplay : MonoBehaviour {

        Dictionary<string, MessageStateWrapper> currentStates;

        // Start is called just before any of the
        // Update methods is called the first time.
        void Start () {
            
        }
        
        // Update is called every frame, if the
        // MonoBehaviour is enabled.
        void Update () {
            
        }

        public void SetState(string id, string message, State_Info_Type infoType)
        {
            if (currentStates == null)
                currentStates = new Dictionary<string, MessageStateWrapper>();
            
                var state = new MessageStateWrapper();
                state.Message = message;
                state.StateType = infoType;

            if (currentStates.ContainsKey(id)) { 
                currentStates[id] = state;
            }
            else
            {
                currentStates.Add(id, state);
            }

            RenderStates();
        }

        private void RenderStates()
        {
            var textComponents = transform.GetComponentsInChildren<Text>();

            if (textComponents.Length < currentStates.Count)
            {
                var delta = currentStates.Count - textComponents.Length;

                var prototype = textComponents.First();

                for (int i = 0; i < delta; i++)
                {
                    var newTextComponent = Instantiate<Text>(prototype);
                    newTextComponent.rectTransform.SetParent(this.transform);
                }
            }
            else if (textComponents.Length > currentStates.Count)
            {
                var delta = textComponents.Length - currentStates.Count;
                
                for (int i = 0; i < delta; i++)
                {
                    var toRemove = transform.GetChild(i);
                    Destroy(toRemove);
                }
            }

            var statesToWrite = currentStates.Values.Count;

            for (int i = 0; i < statesToWrite; i++)
            {
                var child = transform.GetChild(i);
                
                var state = currentStates.ElementAt(i).Value;

                var textComponent = child.GetComponent<Text>();
                textComponent.text = state.Message;

                switch (state.StateType)    
                {
                    case State_Info_Type.INFO:
                        textComponent.color = Color.black;
                        break;
                    case State_Info_Type.WARNING:
                        textComponent.color = Color.yellow;
                        break;
                    case State_Info_Type.ERROR:
                        textComponent.color = Color.red;
                        break;
                    default:
                        break;
                }
            }
        }


        class MessageStateWrapper
        {
            string message;
            public string Message
            {
                set { message = value; }
                get { return message; }
            }

            State_Info_Type stateType;
            public State_Info_Type StateType
            {
                set { stateType = value; }
                get { return stateType; }
            }
        }
    }

}