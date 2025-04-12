from motor.motor_asyncio import AsyncIOMotorClient

MONGO_DETAILS = "mongodb+srv://tccviolao0:Gm5WyepA2K0FusKm@cluster0.jouwrtd.mongodb.net/"
DATABASE_NAME = "LLM"

client = None
db = None

async def connect_to_mongo():
    global client, db
    client = AsyncIOMotorClient(MONGO_DETAILS)
    db = client[DATABASE_NAME]

async def close_mongo_connection():
    global client
    client.close()
