//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class Cannon : Photon.MonoBehaviour
{
    public Transform ballPoint;
    public Transform barrel;
    private Quaternion correctBarrelRot = Quaternion.identity;
    private Vector3 correctPlayerPos = Vector3.zero;
    private Quaternion correctPlayerRot = Quaternion.identity;
    public float currentRot = 0f;
    public Transform firingPoint;
    public bool isCannonGround;
    public GameObject myCannonBall;
    public LineRenderer myCannonLine;
    public HERO myHero;
    public string settings;
    public float SmoothingDelay = 5f;

    public void Awake()
    {
        if (photonView != null)
        {
            photonView.observed = this;
            barrel = transform.Find("Barrel");
            correctPlayerPos = transform.position;
            correctPlayerRot = transform.rotation;
            correctBarrelRot = barrel.rotation;
            if (photonView.isMine)
            {
                firingPoint = barrel.Find("FiringPoint");
                ballPoint = barrel.Find("BallPoint");
                myCannonLine = ballPoint.GetComponent<LineRenderer>();
                if (gameObject.name.Contains("CannonGround"))
                {
                    isCannonGround = true;
                }
            }
            if (PhotonNetwork.isMasterClient)
            {
                var owner = photonView.owner;
                if (FengGameManagerMKII.instance.allowedToCannon.ContainsKey(owner.ID))
                {
                    settings = FengGameManagerMKII.instance.allowedToCannon[owner.ID].settings;
                    photonView.RPC("SetSize", PhotonTargets.All, new object[] { settings });
                    var viewID = FengGameManagerMKII.instance.allowedToCannon[owner.ID].viewID;
                    FengGameManagerMKII.instance.allowedToCannon.Remove(owner.ID);
                    var component = PhotonView.Find(viewID).gameObject.GetComponent<CannonPropRegion>();
                    if (component != null)
                    {
                        component.disabled = true;
                        component.destroyed = true;
                        PhotonNetwork.Destroy(component.gameObject);
                    }
                }
                else if (!(owner.isLocal || FengGameManagerMKII.instance.restartingMC))
                {
                    FengGameManagerMKII.instance.kickPlayerRC(owner, false, "spawning cannon without request.");
                }
            }
        }
    }

    public void Fire()
    {
        if (myHero.skillCDDuration <= 0f)
        {
            var obj2 = PhotonNetwork.Instantiate("FX/boom2", firingPoint.position, firingPoint.rotation, 0);
            foreach (var collider in obj2.GetComponentsInChildren<EnemyCheckCollider>())
            {
                collider.dmg = 0;
            }
            myCannonBall = PhotonNetwork.Instantiate("RCAsset/CannonBallObject", ballPoint.position, firingPoint.rotation, 0);
            myCannonBall.rigidbody.velocity = firingPoint.forward * 300f;
            myCannonBall.GetComponent<CannonBall>().myHero = myHero;
            myHero.skillCDDuration = 3.5f;
        }
    }

    public void OnDestroy()
    {
        if (PhotonNetwork.isMasterClient && !FengGameManagerMKII.instance.isRestarting)
        {
            var strArray = settings.Split(new char[] { ',' });
            if (strArray[0] == "photon")
            {
                if (strArray.Length > 15)
                {
                    var go = PhotonNetwork.Instantiate("RCAsset/" + strArray[1] + "Prop", new Vector3(Convert.ToSingle(strArray[12]), Convert.ToSingle(strArray[13]), Convert.ToSingle(strArray[14])), new Quaternion(Convert.ToSingle(strArray[15]), Convert.ToSingle(strArray[0x10]), Convert.ToSingle(strArray[0x11]), Convert.ToSingle(strArray[0x12])), 0);
                    go.GetComponent<CannonPropRegion>().settings = settings;
                    go.GetPhotonView().RPC("SetSize", PhotonTargets.AllBuffered, new object[] { settings });
                }
                else
                {
                    PhotonNetwork.Instantiate("RCAsset/" + strArray[1] + "Prop", new Vector3(Convert.ToSingle(strArray[2]), Convert.ToSingle(strArray[3]), Convert.ToSingle(strArray[4])), new Quaternion(Convert.ToSingle(strArray[5]), Convert.ToSingle(strArray[6]), Convert.ToSingle(strArray[7]), Convert.ToSingle(strArray[8])), 0).GetComponent<CannonPropRegion>().settings = settings;
                }
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(barrel.rotation);
        }
        else
        {
            correctPlayerPos = (Vector3) stream.ReceiveNext();
            correctPlayerRot = (Quaternion) stream.ReceiveNext();
            correctBarrelRot = (Quaternion) stream.ReceiveNext();
        }
    }

    [RPC]
    public void SetSize(string settings, PhotonMessageInfo info)
    {
        if (info.sender.isMasterClient)
        {
            var strArray = settings.Split(new char[] { ',' });
            if (strArray.Length > 15)
            {
                var a = 1f;
                GameObject gameObject = null;
                gameObject = this.gameObject;
                if (strArray[2] != "default")
                {
                    if (strArray[2].StartsWith("transparent"))
                    {
                        float num2;
                        if (float.TryParse(strArray[2].Substring(11), out num2))
                        {
                            a = num2;
                        }
                        foreach (var renderer in gameObject.GetComponentsInChildren<Renderer>())
                        {
                            renderer.material = (Material) FengGameManagerMKII.RCassets.Load("transparent");
                            if ((Convert.ToSingle(strArray[10]) != 1f) || (Convert.ToSingle(strArray[11]) != 1f))
                            {
                                renderer.material.mainTextureScale = new Vector2(renderer.material.mainTextureScale.x * Convert.ToSingle(strArray[10]), renderer.material.mainTextureScale.y * Convert.ToSingle(strArray[11]));
                            }
                        }
                    }
                    else
                    {
                        foreach (var renderer in gameObject.GetComponentsInChildren<Renderer>())
                        {
                            if (!renderer.name.Contains("Line Renderer"))
                            {
                                renderer.material = (Material) FengGameManagerMKII.RCassets.Load(strArray[2]);
                                if ((Convert.ToSingle(strArray[10]) != 1f) || (Convert.ToSingle(strArray[11]) != 1f))
                                {
                                    renderer.material.mainTextureScale = new Vector2(renderer.material.mainTextureScale.x * Convert.ToSingle(strArray[10]), renderer.material.mainTextureScale.y * Convert.ToSingle(strArray[11]));
                                }
                            }
                        }
                    }
                }
                var x = gameObject.transform.localScale.x * Convert.ToSingle(strArray[3]);
                x -= 0.001f;
                var y = gameObject.transform.localScale.y * Convert.ToSingle(strArray[4]);
                var z = gameObject.transform.localScale.z * Convert.ToSingle(strArray[5]);
                gameObject.transform.localScale = new Vector3(x, y, z);
                if (strArray[6] != "0")
                {
                    var color = new Color(Convert.ToSingle(strArray[7]), Convert.ToSingle(strArray[8]), Convert.ToSingle(strArray[9]), a);
                    foreach (var filter in gameObject.GetComponentsInChildren<MeshFilter>())
                    {
                        var mesh = filter.mesh;
                        var colorArray = new Color[mesh.vertexCount];
                        for (var i = 0; i < mesh.vertexCount; i++)
                        {
                            colorArray[i] = color;
                        }
                        mesh.colors = colorArray;
                    }
                }
            }
        }
    }

    public void Update()
    {
        if (!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, correctPlayerPos, Time.deltaTime * SmoothingDelay);
            transform.rotation = Quaternion.Lerp(transform.rotation, correctPlayerRot, Time.deltaTime * SmoothingDelay);
            barrel.rotation = Quaternion.Lerp(barrel.rotation, correctBarrelRot, Time.deltaTime * SmoothingDelay);
        }
        else
        {
            var vector = new Vector3(0f, -30f, 0f);
            var position = ballPoint.position;
            var vector3 = ballPoint.forward * 300f;
            var num = 40f / vector3.magnitude;
            myCannonLine.SetWidth(0.5f, 40f);
            myCannonLine.SetVertexCount(100);
            for (var i = 0; i < 100; i++)
            {
                myCannonLine.SetPosition(i, position);
                position += (vector3 * num) + (((0.5f * vector) * num) * num);
                vector3 += vector * num;
            }
            var num3 = 30f;
            if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonSlow))
            {
                num3 = 5f;
            }
            if (isCannonGround)
            {
                if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonForward))
                {
                    if (currentRot <= 32f)
                    {
                        currentRot += Time.deltaTime * num3;
                        barrel.Rotate(new Vector3(0f, 0f, Time.deltaTime * num3));
                    }
                }
                else if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonBack) && (currentRot >= -18f))
                {
                    currentRot += Time.deltaTime * -num3;
                    barrel.Rotate(new Vector3(0f, 0f, Time.deltaTime * -num3));
                }
                if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonLeft))
                {
                    transform.Rotate(new Vector3(0f, Time.deltaTime * -num3, 0f));
                }
                else if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonRight))
                {
                    transform.Rotate(new Vector3(0f, Time.deltaTime * num3, 0f));
                }
            }
            else
            {
                if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonForward))
                {
                    if (currentRot >= -50f)
                    {
                        currentRot += Time.deltaTime * -num3;
                        barrel.Rotate(new Vector3(Time.deltaTime * -num3, 0f, 0f));
                    }
                }
                else if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonBack) && (currentRot <= 40f))
                {
                    currentRot += Time.deltaTime * num3;
                    barrel.Rotate(new Vector3(Time.deltaTime * num3, 0f, 0f));
                }
                if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonLeft))
                {
                    transform.Rotate(new Vector3(0f, Time.deltaTime * -num3, 0f));
                }
                else if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonRight))
                {
                    transform.Rotate(new Vector3(0f, Time.deltaTime * num3, 0f));
                }
            }
            if (FengGameManagerMKII.inputRC.isInputCannon(InputCodeRC.cannonFire))
            {
                Fire();
            }
            else if (FengGameManagerMKII.inputRC.isInputCannonDown(InputCodeRC.cannonMount))
            {
                if (myHero != null)
                {
                    myHero.isCannon = false;
                    myHero.myCannonRegion = null;
                    Camera.main.GetComponent<IN_GAME_MAIN_CAMERA>().setMainObject(myHero.gameObject, true, false);
                    myHero.baseRigidBody.velocity = Vector3.zero;
                    myHero.photonView.RPC("ReturnFromCannon", PhotonTargets.Others, new object[0]);
                    myHero.skillCDLast = myHero.skillCDLastCannon;
                    myHero.skillCDDuration = myHero.skillCDLast;
                }
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}

