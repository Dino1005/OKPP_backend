﻿using Google.Cloud.Firestore;

namespace Repository
{
    public class Database
    {
        public readonly FirestoreDb db = FirestoreDb.Create("okpp-a6a02");

        public async Task<List<Dictionary<string, object>>> GetAll(string collection)
        {
            CollectionReference collectionReference = db.Collection(collection);
            QuerySnapshot snapshot = await collectionReference.GetSnapshotAsync();

            List<Dictionary<string, object>> documentDictionary = new();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                documentDictionary.Add(document.ToDictionary());
            }

            return documentDictionary;
        }

        public async Task<Dictionary<string, object>> GetById(string collection, string id)
        {
            DocumentReference documentReference = db.Collection(collection).Document(id);
            DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();

            return snapshot.Exists ? snapshot.ToDictionary() : null;
        }
    }
}
