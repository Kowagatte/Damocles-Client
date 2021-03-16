extends Node

# Declare member variables here. Examples:
# var a = 2
# var b = "text"

# Called when the node enters the scene tree for the first time.
func _ready():
	get_tree().connect("network_peer_connected", self, "peer_connected")
	get_tree().connect("network_peer_disconnected", self, "peer_disconnected")
	get_tree().connect("connected_to_server", self, "connection_server")
	get_tree().connect("connection_failed", self, "connection_failed")
	get_tree().connect("server_disconnected", self, "connection_disconnect")
	
	var peer = NetworkedMultiplayerENet.new()
	peer.create_client("127.0.0.1", 5876)
	get_tree().set_network_peer(peer)

func peer_connected(id):
	if id == 1:
		return
	print("Client ", str(id), " connected!")

func peer_disconnected(id):
	print("Client ", str(id), " disconnected.")

func connection_server():
	print("Successfully connected to server!")
	print("Unique ID of this client: ", str(get_tree().get_network_unique_id()))

func connection_failed():
	print("Cannot connect to the server.")

func connection_disconnect():
	print("Disconnected from the server.")


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
