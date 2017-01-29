using UnityEngine;
using System.Collections;

public class NetBehaviour : MonoBehaviour {

    [Serializeable]
    public bool require_reliable;

    [Serializable]
    public byte owner_id;

    byte client_id;

    network_manager n_manager_script;

    bool reliable_message = false;

    bool hasAuthority;

    /* client objects
    public GameObject camera_rig;
    public GameObject left_controller;
    public GameObject right_controller;

    public GameObject left_hand;
    public GameObject right_hand;*/


    /* buffer values
    float left_x;
    float left_y;
    float left_z;

    float right_x;
    float right_y;
    float right_z;
    */

    //trigger


    virtual void Start()
    {
        n_manager_script = GameObject.Find("Custom Network Manager(Clone)").GetComponent<network_manager>();
        client_id = (byte)(n_manager_script.client_players_amount);
        hasAuthority = (owner_id == client_id);
    }

    virtual void Update()
    {
        if (n_manager_script != null)
        {
            if (require_reliable)
            {
                reliable_message = n_manager_script.reliable_message;
            }
            update_world_state();
        }
    }

    virtual void ReadReliableBuffer();

    //if not owner and not host, do nothing, else:
    void update_world_state()
    {
        if (client_id == owner)
        {
            Read_Camera_Rig();
        }
        else
        {
            left_hand.transform.position = Vector3.Lerp(left_hand.transform.position, new Vector3(left_x, left_y, left_z), 0.1f);
            right_hand.transform.position = Vector3.Lerp(right_hand.transform.position, new Vector3(right_x, right_y, right_z), 0.1f);

            //left_hand.transform.position = new Vector3(left_x, left_y, left_z);
            //right_hand.transform.position = new Vector3(right_x, right_y, right_z);
        }
    }

    void Read_Camera_Rig()
    {
        left_hand.transform.position = left_controller.transform.position;
        right_hand.transform.position = right_controller.transform.position;

    }

    public byte get_client_player_number()
    {
        return client_id;
    }


    // ----------------------------
    // Functions that use Block Copy
    // ----------------------------

    void client_send_reliable_message(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        Debug.Log("CLICKED");
        if (client_id == 1)
        {
            n_manager_script.server_send_reliable();
        }
        else
        {
            n_manager_script.client_send_reliable();
        }
    }


    // The client get its values/inputs to send to the server
    void client_send_values()
    {
        float[] left_controller_values = { left_controller.transform.position.x,
                                           left_controller.transform.position.y,
                                           left_controller.transform.position.z };
        float[] right_controller_values = { right_controller.transform.position.x,
                                            right_controller.transform.position.y,
                                            right_controller.transform.position.z };

        n_manager_script.send_from_client(1, left_controller_values);
        n_manager_script.send_from_client(2, right_controller_values);

    }



    // Server Updates the server larger buffer it is going to send
    public void server_get_values_to_send()
    {

        float[] left_controller_values = { left_controller.transform.position.x,
                                           left_controller.transform.position.y,
                                           left_controller.transform.position.z };
        float[] right_controller_values = { right_controller.transform.position.x,
                                            right_controller.transform.position.y,
                                            right_controller.transform.position.z };



        n_manager_script.send_from_server(1, left_controller_values);
        n_manager_script.send_from_server(2, right_controller_values);

    }




    // Client get values from the server buffer
    void client_update_values()
    {

        float[] left_controller_values = n_manager_script.client_read_server_buffer(1);
        float[] right_controller_values = n_manager_script.client_read_server_buffer(2);

        left_x = left_controller_values[0];
        left_y = left_controller_values[1];
        left_z = left_controller_values[2];

        right_x = right_controller_values[0];
        right_y = right_controller_values[1];
        right_z = right_controller_values[2];

    }

    // Server Get values from the client buffer, so the client inputs
    public void server_get_client_hands()
    {
        float[] left_controller_values = n_manager_script.server_read_client_buffer(1);
        float[] right_controller_values = n_manager_script.server_read_client_buffer(2);

        left_x = left_controller_values[0];
        left_y = left_controller_values[1];
        left_z = left_controller_values[2];

        //Debug.Log("left controller vector3: " + right_x + " " + right_y + " " + right_z);

        right_x = right_controller_values[0];
        right_y = right_controller_values[1];
        right_z = right_controller_values[2];
    }





}